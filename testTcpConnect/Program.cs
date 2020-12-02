using System;

namespace testTcpConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClientBusiness.RemoteIp = "193.1.105.115";
            TcpClientBusiness.RemotePort = 2268;

            TcpClientBusiness.ConnectToServer();

            string command = "APPLy 28.5,5.5\r\n";

            byte[] sendCmd = System.Text.Encoding.ASCII.GetBytes(command);

            while (TcpClientBusiness.IsConnected==false)
            {
                ;
            }

            TcpClientBusiness.SendData(sendCmd);

            command = "APPLy?\r\n";

            sendCmd = System.Text.Encoding.ASCII.GetBytes(command);
            TcpClientBusiness.SendData(sendCmd);


            while (TcpClientBusiness.ResponseBytes.Count==0)
            {
                ;
            }

            if (TcpClientBusiness.ResponseBytes.Count>0)
            {
                byte[] res = TcpClientBusiness.ResponseBytes[0];

                string resstr = System.Text.Encoding.ASCII.GetString(res);

                Console.WriteLine($"Respones = {resstr}");
            }

            command = "OUTPut:DELay:ON 0\r\n";
            TcpClientBusiness.SendData(System.Text.Encoding.ASCII.GetBytes(command));

            command = "OUTPut:DELay:ON?\r\n";
            TcpClientBusiness.SendData(System.Text.Encoding.ASCII.GetBytes(command));

            while (TcpClientBusiness.ResponseBytes.Count == 0)
            {
                ;
            }

            if (TcpClientBusiness.ResponseBytes.Count > 1)
            {
                byte[] res = TcpClientBusiness.ResponseBytes[TcpClientBusiness.ResponseBytes.Count-1];

                string resstr = System.Text.Encoding.ASCII.GetString(res);

                Console.WriteLine($"Respones = {resstr}");
            }

            command = "OUTPut:STATe:IMMediate 1\r\n";
            TcpClientBusiness.SendData(System.Text.Encoding.ASCII.GetBytes(command));

            Console.Read();
            TcpClientBusiness.CloseConnect();
        }
    }
}
