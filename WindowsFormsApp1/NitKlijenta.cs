﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domen;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace WindowsFormsApp1
{
    class NitKlijenta
    {
        private NetworkStream tok;
        BinaryFormatter formater;

        public NitKlijenta(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();

            ThreadStart ts = obradi;
            new Thread(ts).Start();
        }

        void obradi()
        {
            try
            {
                int operacija = 0;
                while(operacija!= (int)Operacije.Kraj)
                {
                    TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;

                    switch(transfer.Operacija)
                    {
                        case Operacije.Kraj: operacija = 1;
                            break;
                        default:
                            break;
                    }
                }


            }
            catch (Exception)
            {

              
            }      
        }
    }
}
