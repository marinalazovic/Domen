using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Domen;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;




namespace Klijent
{
    public class Komunikacija
    {
        TcpClient klijent;
        NetworkStream tok;
        BinaryFormatter formater;

        public bool poveziSeNaSever()
        {
            try
            {
                klijent = new TcpClient("localhost", 20000);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public void kraj()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.Kraj;
            formater.Serialize(tok, transfer);
        }
    }
}
