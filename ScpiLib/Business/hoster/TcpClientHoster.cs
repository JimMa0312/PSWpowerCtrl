using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ScpiLib.Business.hoster
{
    public class TcpClientHoster : IHoster, IHosterLisener
    {
        private bool _isConnect;

        private TcpClient _tcpClient;
        private NetworkStream _networksStream;
        private Queue<byte[]> _responseByte;

        private string _targetIp;
        private int _targetPort;

        public TcpClientHoster(string targetIp, int targetPort)
            : this()
        {
            _targetIp = targetIp;
            _targetPort = targetPort;
        }

        private TcpClientHoster()
        {
            _tcpClient = new TcpClient();
            _isConnect = false;
            _responseByte = new Queue<byte[]>();
        }

        public void connect()
        {
            try
            {
                ConnectToServerAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                disconnect();
            }
            
        }

        public void disconnect()
        {
            _tcpClient.Close();

            _isConnect = false;
        }

        public bool getIsConnect()
        {
            return _isConnect;
        }

        public int recvData(out List<byte> buffer)
        {
            throw new NotImplementedException();
        }

        public int sendData(List<byte> buffer)
        {
            int result= sendDataAsync(buffer).Result;

            return result;
        }

        private async Task<int> sendDataAsync(List<byte> buffer)
        {
            int result = 0;
            try
            {
                if (_networksStream != null && _tcpClient.Connected == true)
                {
                    if (_networksStream.CanWrite && buffer != null && buffer.Count > 0)
                    {
                        await _networksStream.WriteAsync(buffer.ToArray(), 0, buffer.Count);
                        await _networksStream.FlushAsync();
                        result = buffer.Count;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 根据服务器Ip地址和服务器活动端口，通过TCP与服务器建立通信链路。
        /// </summary>
        private async void ConnectToServerAsync()
        {
            try
            {
                //开始异步连接服务器
                //_tcpClient.BeginConnect(_targetIp, _targetPort, new AsyncCallback(AsynConnect), _tcpClient);
                var task = _tcpClient.ConnectAsync(_targetIp, _targetPort);

                await Task.WhenAny(task, Task.Delay(2000));

                if(!task.IsCompleted || task.IsFaulted)
                {
                    //TODO 设置连接错误
                    throw new Exception($"远程设别{_targetIp} 连接超时");
                    
                }
                else if(_tcpClient.Connected)
                {
                    //TCP握手成功
                    _isConnect = true;
                    _networksStream = _tcpClient.GetStream();
                }
            }
            catch (Exception ex)
            {
                _isConnect = false;
                throw;
            }
        }

        private void AsynConnect(IAsyncResult ar)
        {
            try
            {
                _tcpClient.EndConnect(ar);

                _isConnect = true;

                _networksStream = _tcpClient.GetStream();
                byte[] TempBytes = new byte[1024];

                _networksStream.BeginRead(TempBytes, 0, TempBytes.Length, new AsyncCallback(AsynReceiveData), TempBytes);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void AsynReceiveData(IAsyncResult ar)
        {
            byte[] currentByte = (byte[])ar.AsyncState;

            try
            {
                int num = _networksStream.EndRead(ar);
                _responseByte.Enqueue(currentByte);

                byte[] NewBytes = new byte[1024];
                _networksStream.BeginRead(NewBytes, 0, NewBytes.Length, new AsyncCallback(AsynReceiveData), NewBytes);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
