using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace testTcpConnect
{
    public class TcpClientBusiness
    {
        #region 自定义参数
        private static TcpClient tcpClient;
        private static NetworkStream networkStream;
        public static List<byte[]> ResponseBytes = new List<byte[]>();

        public static string RemoteIp = string.Empty;

        public static int RemotePort = -1;

        public static bool IsConnected = false;
        #endregion

        /// <summary>
        /// 打开TCP链接
        /// </summary>
        public static void ConnectToServer()
        {
            try
            {
                tcpClient = new TcpClient();

                tcpClient.BeginConnect(RemoteIp, RemotePort, new AsyncCallback(AsynConnect), tcpClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AsynConnect(IAsyncResult ar)
        {
            try
            {
                tcpClient.EndConnect(ar);

                Console.WriteLine("Connect Ok!");

                IsConnected = true;
                networkStream = tcpClient.GetStream();
                byte[] TempBytes = new byte[1024];

                networkStream.BeginRead(TempBytes, 0, TempBytes.Length, new AsyncCallback(AsynReceiveData), TempBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SendData(byte[] SendBytes)
        {
            try
            {
                if(networkStream.CanWrite && SendBytes != null && SendBytes.Length>0)
                {
                    networkStream.Write(SendBytes, 0, SendBytes.Length);
                    networkStream.Flush();
                }
            }
            catch (Exception ex)
            {
                CloseConnect();

                Console.WriteLine(ex.Message);
            }
        }

        private static void AsynReceiveData(IAsyncResult ar)
        {
            byte[] CurrentBytes = (byte[])ar.AsyncState;

            try
            {
                int num = networkStream.EndRead(ar);
                ResponseBytes.Add(CurrentBytes);

                byte[] NewBytes = new byte[1024];
                networkStream.BeginRead(NewBytes, 0, NewBytes.Length, new AsyncCallback(AsynReceiveData), NewBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CloseConnect()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
                Console.WriteLine("TCP disconnect");
                IsConnected = false;
            }
        }
    }
}
