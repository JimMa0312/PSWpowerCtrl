using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

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


        public bool connect()
        {
            throw new NotImplementedException();
        }

        public bool disconnect()
        {
            throw new NotImplementedException();
        }

        public bool getIsConnect()
        {
            throw new NotImplementedException();
        }

        public int recvData(out List<byte> buffer)
        {
            throw new NotImplementedException();
        }

        public int sendData(List<byte> buffer)
        {
            int result = 0;
            try
            {
                if(_networksStream.CanWrite && buffer!=null && buffer.Count>0)
                {
                    _networksStream.Write(buffer.ToArray(), 0, buffer.Count);
                    _networksStream.Flush();
                    result = buffer.Count;
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
        public void connectToServer()
        {
            try
            {
                //开始异步连接服务器
                _tcpClient.BeginConnect(_targetIp, _targetPort, new AsyncCallback(AsynConnect), _tcpClient);
            }
            catch (Exception ex)
            {

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
