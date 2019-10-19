using System;
using System.Threading;

namespace Gameboyemu
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            MainClass foo = new MainClass();
            while (b != 10241)
            {
                foo.Update();
            }
        }
        //read and write
        public int cpuWrite;
        public int cpuRead;
        //cpu registers
        public int A;
        public int B;
        public int C;
        public int PC;
        public int D;
        public int SP;
        public int E;
        public int F;
        public int L;
        public int H;
        short HL;
        //Flags/'
        public int c;
        //not a register
        static int b;
        ConsoleKeyInfo input;
        public int[] cpuBus = new int[65535];

        public void controller()
        {
            cpuBus[65280] = 48;
            if (Console.KeyAvailable == true) {
                input = Console.ReadKey();
            }
            System.Threading.Thread.Sleep((int)0.0);
            if (input.Key == ConsoleKey.W | input.Key == ConsoleKey.S | input.Key == ConsoleKey.A | input.Key == ConsoleKey.D)
            {
                cpuBus[65280] -= 32;
                //while (KeyCode == (char)Keys.W)
                {
                    cpuBus[65280] += 8;
                }

                while (input.Key == ConsoleKey.S)
                {
                    cpuBus[65280] += 4;
                }

                while (input.Key == ConsoleKey.A)
                {
                    cpuBus[65280] += 2;
                }

                while (input.Key == ConsoleKey.D)
                {
                    cpuBus[65280] += 2;
                }
            }

            if (input.Key == ConsoleKey.J | input.Key == ConsoleKey.K | input.Key == ConsoleKey.B | input.Key == ConsoleKey.V)
            {
                cpuBus[65280] -= 16;
                while (input.Key == ConsoleKey.J) {
                    cpuBus[65280] += 2;
                }

                while (input.Key == ConsoleKey.K)
                {
                    cpuBus[65280] += 2;
                }
            }
        }

        public void Update()
        {
            //controller();
            //Console.Clear();
            //Console.Write(cpuBus[1]);
            //Console.Write(" " + cpuBus[2]);
            //LDA(B);
            //Wrap();
            var Iinput = Console.ReadLine();
            HextoCs(Iinput);
            Console.WriteLine("Registers A:" + A + " and B:" + B);
            Console.WriteLine(cpuBus[1]);
            HL = (short)((H << 8) | L);
            //Console.WriteLine("CpuRead: " + cpuRead);
            //Console.WriteLine(cpuBus[65280]);
        }
        public void HextoCs(string Hex) {
            string[] parsedHex = Hex.Split(' ');
            if (parsedHex[0] == "3C") {
                A++;
            }
            if (parsedHex[0] == "2C")
            {
                L++;
            }
            if (parsedHex[0] == "1C")
            {
                E--;
            }
            if (parsedHex[0] == "0C")
            {
                C--;
            }
            if (parsedHex[0] == "2D")
            {
                L--;
            }
            if (parsedHex[0] == "1D")
            {
                E--;
            }
            if (parsedHex[0] == "0D")
            {
                C--;
            }
            if (parsedHex[0] == "3D") {
                A--;
            }
            if (parsedHex[0] == "2B")
            {
                H--;
                if (H < 0) {
                    L--;
                    H = 0;
                }
            }
            if (parsedHex[0] == "0B")
            {
                DEC(B);
                if (B < 0)
                {
                    C--;
                    B = 0;
                }
            }
            if (parsedHex[0] == "1B")
            {
                DEC(D);
                if (D < 0)
                {
                    E--;
                    D = 0;
                }
            }
            if (parsedHex[0] == "3B")
            {
                PC--;
            }
            if (parsedHex[0] == "80")
            {
                A += B;
            }
            if (parsedHex[0] == "81")
            {
                A += C;
            }
            if (parsedHex[0] == "82")
            {
                A += D;
            }
            if (parsedHex[0] == "83")
            {
                A += E;
            }
            if (parsedHex[0] == "84")
            {
                A += H;
            }
            if (parsedHex[0] == "85")
            {
                A += L;
            }
            if (parsedHex[0] == "87")
            {
                A += A;
            }
            if (parsedHex[0] == "88")
            {
                A += B + c;
            }
            if (parsedHex[0] == "89")
            {
                A += C + c;
            }
            if (parsedHex[0] == "8A")
            {
                A += D + c;
            }
            if (parsedHex[0] == "8B")
            {
                A += E + c;
            }
            if (parsedHex[0] == "8C")
            {
                A += H + c;
            }
            if (parsedHex[0] == "8D")
            {
                A += L + c;
            }
            if (parsedHex[0] == "8E")
            {
                A += HL + c;
            }
            if (parsedHex[0] == "8F")
            {
                A += A + c;
            }
            if (parsedHex[0] == "90")
            {
                A -= B;
            }
            if (parsedHex[0] == "91")
            {
                A -= C;
            }
            if (parsedHex[0] == "92")
            {
                A -= D;
            }
            if (parsedHex[0] == "93")
            {
                A -= E;
            }
            if (parsedHex[0] == "94")
            {
                A -= H;
            }
            if (parsedHex[0] == "95")
            {
                A -= L;
            }
            if (parsedHex[0] == "96")
            {
                A -= HL;
            }
            if (parsedHex[0] == "97")
            {
                A -= A;
            }
            if (parsedHex[0] == "98")
            {
                A -= B + c;
            }
            if(parsedHex[0] == "99")
            {
                A -= C + c;
            }
            if (parsedHex[0] == "9A")
            {
                A -= D + c;
            }
            if (parsedHex[0] == "9B")
            {
                A -= E + c;
            }
            if (parsedHex[0] == "9C")
            {
                A -= H + c;
            }
            if (parsedHex[0] == "9D")
            {
                A -= L + c;
            }
            if (parsedHex[0] == "9E")
            {
                A -= HL + c;
            }
            if (parsedHex[0] == "9F")
            {
                A -= A + c;
            }
        }
        public void ASMtoCs(string ASM) {
            string[] parsedASM = ASM.Split(' ');
            //INC
            if (parsedASM[0] == "INCA") {
                INCA();
            }

            if (parsedASM[0] == "INC")
            {
                try
                {
                    INC();
                }
                catch (System.NullReferenceException)
                { }
            }
            //DEC
            if (parsedASM[0] == "DECA")
            {
                DECA();
            }

            if (parsedASM[0] == "DEC")
            {
                try
                {
                    DEC((int)this.GetType().GetField(parsedASM[1]).GetValue(this));
                    DEC(parsedASM[1]);
                }
                catch (System.NullReferenceException)
                { }
            }

            //LDA



            if (parsedASM[0] == "LDA")
            {
                try
                {
                    LDA((int)GetType().GetField(parsedASM[1]).GetValue(this));
                    LDA(parsedASM[1]);
                }
                catch (System.NullReferenceException)
                { }
            }

            if (parsedASM[0] == "LD")
            {
                try
                {
                    LD(parsedASM[1], (int)GetType().GetField(parsedASM[2]).GetValue(this));
                    LD(parsedASM[1], parsedASM[2]);
                }
                catch (System.NullReferenceException)
                { }
            }

            //OR

            if (parsedASM[0] == "OR")
            {
                try
                {
                    OR(parsedASM[1].Split(',')[1], parsedASM[2].Split(',')[2]);
                    OR(parsedASM[1].Split(',')[1], (int)this.GetType().GetField(parsedASM[2].Split(',')[2]).GetValue(this));
                    OR((int)this.GetType().GetField(parsedASM[1].Split(',')[0]).GetValue(this), parsedASM[2]);
                    OR((int)this.GetType().GetField(parsedASM[1].Split(',')[0]).GetValue(this), (int)this.GetType().GetField(parsedASM[2]).GetValue(this));
                }
                catch (System.NullReferenceException)
                { }
                catch (System.IndexOutOfRangeException)
                { }
            }
            //XOR
            if (parsedASM[0] == "XOR")
            {
                try
                {
                    XOR(parsedASM[1].Split(',')[1], parsedASM[2].Split(',')[2]);
                    XOR(parsedASM[1].Split(',')[1], (int)this.GetType().GetField(parsedASM[2].Split(',')[2]).GetValue(this));
                    XOR((int)this.GetType().GetField(parsedASM[1].Split(',')[0]).GetValue(this), parsedASM[2]);
                    XOR((int)this.GetType().GetField(parsedASM[1].Split(',')[0]).GetValue(this), (int)this.GetType().GetField(parsedASM[2]).GetValue(this));
                }
                catch (System.NullReferenceException)
                { }
            }
            //AND
            if (parsedASM[0] == "AND")
            {
                try
                {
                    AND(parsedASM[1].Split(',')[1], parsedASM[2]);
                    AND(parsedASM[1].Split(',')[1], (int)this.GetType().GetField(parsedASM[2].Split(',')[2]).GetValue(this));
                    //AND((int)this.GetType().GetField(parsedASM[1].Split(',')[0]).GetValue(this), parsedASM[2]);
                    //AND((int)this.GetType().GetField(parsedASM[1].Split(',')[0]).GetValue(this), (int)this.GetType().GetField(parsedASM[2]).GetValue(this));
                }
                catch (System.NullReferenceException)
                { }
                catch (System.IndexOutOfRangeException) { }
            }

            //ADD
            if (parsedASM[0] == "ADD")
            {
                    if (String.IsNullOrEmpty(parsedASM[2]))
                    {
                        ADD(Convert.ToInt32(parsedASM[1], 10));
                    }
                    ADD(parsedASM[1].Split(',')[1], parsedASM[2].Split(',')[2]);
                    ADD(parsedASM[1].Split(',')[1], (int)this.GetType().GetField(parsedASM[2].Split(',')[2]).GetValue(this));
                    ADD((int)this.GetType().GetField(parsedASM[1].Split(',')[0]).GetValue(this), parsedASM[2]);
                    ADD((int)this.GetType().GetField(parsedASM[1].Split(',')[0]).GetValue(this), (int)this.GetType().GetField(parsedASM[2]).GetValue(this));
            }
            //SUB
            if (parsedASM[0] == "SUB")
            {
                try
                {
                    if (String.IsNullOrEmpty(parsedASM[2]))
                    {
                        SUB(Convert.ToInt32(parsedASM[1], 10));
                    }
                    SUB(parsedASM[1].Split(',')[1], parsedASM[2].Split(',')[2]);
                    SUB(parsedASM[1].Split(',')[1], (int)this.GetType().GetField(parsedASM[2].Split(',')[2]).GetValue(this));
                    SUB((int)this.GetType().GetField(parsedASM[1].Split(',')[0]).GetValue(this), parsedASM[2]);
                    SUB((int)this.GetType().GetField(parsedASM[1].Split(',')[0]).GetValue(this), (int)this.GetType().GetField(parsedASM[2]).GetValue(this));
                }
                catch (System.NullReferenceException)
                { }
            }
        }

        #region XOR
        public void XOR(int gan, int ganj)
        {
            gan = gan ^ ganj;
        }

        public void XOR(int gan, string ganj)
        {
            cpuRead = Convert.ToInt32(ganj, 16);
            gan = gan ^ cpuRead;
        }
        public void XOR(string gan, string ganj)
        {
            cpuRead = Convert.ToInt32(ganj, 16);
            cpuWrite = Convert.ToInt32(gan, 16);
            cpuWrite = cpuWrite ^ cpuRead;
            cpuWrite = Convert.ToInt32(gan, 16);
        }

        public void XOR(string ganj, int gan)
        {
            cpuWrite = Convert.ToInt32(ganj, 16);

            cpuWrite = cpuWrite ^ gan;
            ganj = "" + cpuWrite;
        }
        #endregion
        #region OR
        public void OR(int gan, int ganj)
        {
            gan = gan | ganj;
        }

        public void OR(int gan, string ganj)
        {
            cpuRead = Convert.ToInt32(ganj, 16);
            gan = gan | cpuRead;
        }

        public void OR(string ganj, int gan)
        {
            cpuWrite = Convert.ToInt32(ganj, 16);

            cpuWrite = cpuWrite | gan;
            ganj = "" + cpuWrite;
        }

        public void OR(string gan, string ganj)
        {
            cpuRead = Convert.ToInt32(ganj, 16);
            cpuWrite = Convert.ToInt32(gan, 16);
            cpuWrite = cpuWrite | cpuRead;
            cpuWrite = Convert.ToInt32(gan, 16);
        }
        #endregion
        #region AND
        
        
        public void AND(string gan, string ganj)
        {
            if (gan.Length == 1) {
                if (gan == "A") {

                }
            } 
            cpuRead = Convert.ToInt32(ganj, 16);
            cpuWrite = Convert.ToInt32(gan, 16);
            cpuWrite = cpuWrite & cpuRead;
            cpuWrite = Convert.ToInt32(gan, 16);
        }

        public void AND(string ganj, int gan)
        {
            cpuWrite = Convert.ToInt32(ganj, 16);

            cpuWrite = cpuWrite & gan;
            ganj = "" + cpuWrite;
        }
        #endregion
        #region INC
        public void INC(int hjadnk)
        {
            hjadnk++;
        }

        public void INC()
        {
            A++;
        }

        public void INCA()
        {
            A++;
        }

        public void INC(string hjadnk)
        {
            if (hjadnk.Length == 1)
            {
                if (hjadnk == "A") {
                    A++;
                }

                if (hjadnk == "B")
                {
                    B++;
                }

                if (hjadnk == "C")
                {
                    C++;
                }
                if (hjadnk == "D")
                {
                    D++;
                }
                if (hjadnk == "E")
                {
                    E++;
                }
                if (hjadnk == "SP")
                {
                    SP++;
                }
            }
            cpuRead = Convert.ToInt32(hjadnk, 16);
            cpuBus[cpuRead]++;
        }
        #endregion
        #region ADD
        public void ADD(int asdaf, int rasraf) {
            asdaf += rasraf;
        }

        public void ADD(int asdaf, string rasraf)
        {
            cpuRead = Convert.ToInt32(rasraf, 16);
            asdaf += cpuBus[cpuRead];
        }
        public void ADD(string asdaf, string rasraf)
        {
            cpuRead = Convert.ToInt32(rasraf, 16);
            cpuWrite = Convert.ToInt32(asdaf, 16);
            cpuBus[cpuWrite] += cpuBus[cpuRead];
        }
        public void ADD(string rasdaf, int asdaf)
        {
            cpuRead = Convert.ToInt32(rasdaf, 16);
            cpuBus[cpuRead] += asdaf;
        }

        public void ADD(int asdaf)
        {
            A += asdaf;
        }

        #endregion
        #region SUB
        public void SUB(int asdaf, int rasraf)
        {
            asdaf += rasraf;
        }

        public void SUB(int asdaf, string rasraf)
        {
            cpuRead = Convert.ToInt32(rasraf, 16);
            asdaf += cpuBus[cpuRead];
        }
        public void SUB(string asdaf, string rasraf)
        {
            cpuRead = Convert.ToInt32(rasraf, 16);
            cpuWrite = Convert.ToInt32(asdaf, 16);
            cpuBus[cpuWrite] -= cpuBus[cpuRead];
        }
        public void SUB(string rasdaf, int asdaf)
        {
            cpuRead = Convert.ToInt32(rasdaf, 16);
            cpuBus[cpuRead] -= asdaf;
        }

        public void SUB(int asdaf)
        {
            A -= asdaf;
        }

        #endregion
        #region DEC
        public void DEC(int hjadnk)
        {
            hjadnk--;
        }

        public void DECA()
        {
            A--;
        }

        public void DEC(string hjadnk)
        {
            cpuRead = Convert.ToInt32(hjadnk, 16);
            cpuBus[cpuRead]--;
        }
        #endregion
        #region LDA
        public void LDA(string hkdbhjfauuoijlnbughoal)
        {
            cpuRead = Convert.ToInt32(hkdbhjfauuoijlnbughoal, 16);
            A = cpuBus[cpuRead];
        }

        public void LDA(int hkdbhjfauuoijlnbughoal)
        {
            A = hkdbhjfauuoijlnbughoal;
        }

        #endregion
        #region LD
        public void LD(int hkdbhjfauuoijlnbughoal, int danj)
        {
            hkdbhjfauuoijlnbughoal = danj;
        }
        public void LD(string danj, int hkdbhjfauuoijlnbughoal)
        {
            
            cpuRead = Convert.ToInt32(danj, 16);
            cpuBus[cpuRead] = hkdbhjfauuoijlnbughoal;
        }

        public void LD(string danj, string hkdbhjfauuoijlnbughoal)
        {
            if (danj.Length == 1)
            {
                if (danj == "A")
                {
                    A = cpuBus[Convert.ToInt32(hkdbhjfauuoijlnbughoal, 16)];
                }

                if (danj == "B")
                {
                    B = cpuBus[Convert.ToInt32(hkdbhjfauuoijlnbughoal, 16)];
                }

                if (danj == "C")
                {
                    C = cpuBus[Convert.ToInt32(hkdbhjfauuoijlnbughoal, 16)];
                }
                if (danj == "D")
                {
                    D = cpuBus[Convert.ToInt32(hkdbhjfauuoijlnbughoal, 16)];
                }
                if (danj == "E")
                {
                    E = cpuBus[Convert.ToInt32(hkdbhjfauuoijlnbughoal, 16)];
                }
                if (danj == "SP")
                {
                    SP = cpuBus[Convert.ToInt32(hkdbhjfauuoijlnbughoal, 16)];
                }
            }
            else if(hkdbhjfauuoijlnbughoal.Length == 4 & danj.Length == 4) {
                cpuRead = Convert.ToInt32(hkdbhjfauuoijlnbughoal, 16);
                cpuBus[Convert.ToInt32(danj, 16)] = cpuRead;
            }
        }

        #endregion
        public void Wrap()
        {
            if (A > 256)
            {
                A -= 256;
                c += 1;
            }

            if (B > 256)
            {
                B -= 256;
                c += 1;
            }

            if (C > 256)
            {
                C -= 256;
                c += 1;
            }
            if (D > 256)
            {
                D -= 256;
                c += 1;
            }
            if (E > 256)
            {
                E -= 256;
                c += 1;
            }

            if (F > 256)
            {
                F -= 256;
                c += 1;
            }

            if (H > 256)
            {
                H -= 256;
                c += 1;
            }

            if (L > 256)
            {
                L -= 256;
                c += 1;
            }

            if (PC > 65535)
            {
                PC -= 65535;
                c += 1;
            }

            if (SP > 65535)
            {
                SP -= 65535;
                c += 1;
            }

            if (cpuRead > 65535) {
                cpuRead -= 65535;
                c += 1;
            }

            if (cpuWrite > 65535)
            {
                cpuWrite -= 65535;
                c += 1;
            }
            if (c > 1)
            {
                c = 0;
            }
        }
    }
}
