/*
 *	This file is part of CANStream.
 *
 *	CANStream program is free software: you can redistribute it and/or modify
 *	it under the terms of the GNU General Public License as published by
 *	the Free Software Foundation, either version 3 of the License, or
 *	(at your option) any later version.
 *
 *	This program is distributed in the hope that it will be useful,
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *	GNU General Public License for more details.
 *
 *	You should have received a copy of the GNU General Public License
 *	along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 *	CANStream Copyright © 2013-2016 whilenotinfinite@gmail.com
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;

namespace NumberBaseConversion
{
    /// <summary>
    /// Classe statique de conversion numérique entre les bases decimale, hexadecimale, binaire et float
    /// </summary>
   
    public static class NumberBaseConverter
    {
        #region Methodes publiques  

        #region Hexa / Decimal

        /// <summary>
        /// Convertit un nombre Hexadecimale en Décimale
        /// </summary>
        /// <param name="HexValue">(string) Valeur Hexadecimale</param>
        /// <returns>(int) Valeur Décimale</returns>
        public static int Hex2Dec(string HexValue)
        {
            return (Int32.Parse(HexValue, System.Globalization.NumberStyles.HexNumber));
        }

        /// <summary>
        /// Convertit un nombre Décimale en Hexadecimale
        /// </summary>
        /// <param name="DecValue">(int) Valeur décimale à convertir</param>
        /// <returns>(string) Valeur Hexadecimale du nombre</returns>
        public static string Dec2Hex(long DecValue)
        {
            return (String.Format("{0:x}", DecValue));
        }

        #endregion

        #region Binaire / Decimal

        /// <summary>
        /// Convertit un nombre Binaire en Decimale
        /// </summary>
        /// <param name="BinValue">(string) Valeur Binaire à convertir</param>
        /// <returns>(int) Valeur décimale du nombre</returns>
        public static int Bin2Dec(string BinValue)
        {
            int taille = BinValue.Length;
            int puissance = taille - 1;
            int soustotal;
            int total = 0;

            if (BinValue == "1")
            {
                total = 1; 
            }
            else
            {
                if (BinValue == "0")
                { 
                    total = 0; 
                }
                else
                {
                    for (int i = 0; i < taille; i++)
                    {
                        if ((puissance >= 0) && (BinValue[i] == '1'))
                        {
                            soustotal = (int)Math.Pow(2, puissance);
                            puissance -= 1;
                            total += soustotal;
                        }
                        else
                        {
                            puissance -= 1;
                        }
                    }
                }
            }
            return total; 
        }

        /// <summary>
        /// Converit un nombre Décimale en Binaire
        /// </summary>
        /// <param name="DecValue">(int) Valeur décimale à convertir</param>
        /// <returns>(string) Valeur binaire du nombre</returns>
        public static string Dec2Bin(long DecValue)
        {
            string res = "";
            int div;
            long i;

            do
            {
                div = 0;
                i = DecValue;
                while (i != 1 && i != 0)
                {
                    i -= 2;
                    div += 1;
                }
                res = Convert.ToString(DecValue - (2 * div)) + res;
                DecValue = div;
            }
            while (DecValue != 0);
            return res;
        }

        #endregion

        #region Hexa / Binaire

        /// <summary>
        /// Convertit un nombre Hexadecimale en Binaire
        /// </summary>
        /// <param name="HexValue">(string) Valeur Hexadecimale à convertir</param>
        /// <returns>(string) Valeur binaire du nombre</returns>
        public static string Hex2Bin(string HexValue)
        {
            string hexa;
            string bin;
            string binaire = "";
            int taille = HexValue.Length;

            for (int i = 0; i < taille; i++)
            {
                hexa = Convert.ToString(HexValue[i]);
                bin = "";
                switch (hexa.ToUpper())
                {
                    case "A": bin += Dec2Bin(10);
                        break;
                    case "B": bin += Dec2Bin(11);
                        break;
                    case "C": bin += Dec2Bin(12);
                        break;
                    case "D": bin += Dec2Bin(13);
                        break;
                    case "E": bin += Dec2Bin(14);
                        break;
                    case "F": bin += Dec2Bin(15);
                        break;
                    default: bin += Dec2Bin(Convert.ToInt32(hexa));
                        break;
                }
                if (bin.Length < 4)
                {
                    for (int j = bin.Length; j < 4; j++)
                    {
                        bin = "0" + bin;
                    }
                }
                //bin += " ";
                binaire += bin;
            }
            return binaire; 
        }

        /// <summary>
        /// Convertit un nombre Binaire en Hexadecimale
        /// </summary>
        /// <param name="BinValue">(string) Valeur Binaire à convertir</param>
        /// <returns>(string) Valeur hexadécimale du nombre</returns>
        public static string Bin2Hex(string BinValue)
        {
            string hexa = "";
            int taille = BinValue.Length;
            int nb;
            string bin;
            int dec;
            int j = 0;
            int zero = taille % 4;

            if (zero > 0)
            {
                for (int k = 1; k <= (4 - zero); k++)
                {
                    BinValue = "0" + BinValue;
                }
            }
            if (taille > 4)
            { nb = (taille / 4) + 1; }
            else
            { nb = 1; }
            for (int i = 1; i < nb; i++)
            {
                bin = "";
                bin += BinValue.Substring(j, 4);
                j += 4;
                dec = Bin2Dec(bin);
                switch (dec)
                {
                    case 10: hexa += "A";
                        break;
                    case 11: hexa += "B";
                        break;
                    case 12: hexa += "C";
                        break;
                    case 13: hexa += "D";
                        break;
                    case 14: hexa += "E";
                        break;
                    case 15: hexa += "F";
                        break;
                    default: hexa += dec;
                        break;
                }
            }
            return hexa;
        }

        #endregion

        #region Double / Float 32 IEEE 754

        /// <summary>
        /// Convertit un double vers une representation en Float32 IEEE 754
        /// </summary>
        /// <param name="DblValue">(double) Nombre à convertir</param>
        /// <returns>(string) representation en Float32 du double donné en argument</returns>
        public static string Double2Float32(double DblValue)
        {
            //Declarations
            int iExp;
            double dNbDec;
            double dMant = 0;
            string sMant = "";
            string sExp;
            string sSgn;
            string sDword = "";
            string sMask = "00000000";

            //Cas de la conversion de 0
            if (DblValue == 0)
            {
                return ("00000000"); //ou 80000000
            }

            //Calcul de l'exposant
            iExp = 127;
            dNbDec = Math.Abs(DblValue);
            while (dNbDec >= 2)
            {
                dNbDec = dNbDec / 2;
                iExp++;
            }

            while (dNbDec < 1)
            {
                dNbDec = dNbDec * 2;
                iExp--;
            }

            sExp = string.Format("{0:x}", iExp);

            //Calcul du signe
            if (Math.Sign((decimal)DblValue) == 1)
            {
                sSgn = "00000000";
            }
            else
            {
                sSgn = "80000000";
            }

            //Calcul de la mantisse
            dMant = (double)(Math.Abs(DblValue) * Math.Pow(2, ((iExp - 127) * -1)) - 1);
            if (dMant > 1)
            {
                dMant = dMant - 1;
            }

            for (int i = 1; i < 7; i++)
            {
                dMant = Math.Abs(dMant) * 16;
                sMant = sMant + string.Format("{0:x}",(int) dMant);
                dMant = dMant - Math.Floor(dMant);
            }

            Int32 hMant = Int32.Parse(sMant, NumberStyles.HexNumber);
            if (! hMant.Equals(hMant & 0xfffffe))
            {
                sMant = string.Format("{0:x}", hMant + 1);
                while (sMant.Length < 6)
                {
                    sMant = "0" + sMant;
                }
            }

            sDword = sExp + sMant;
            Int32 hDword = Int32.Parse(sDword, NumberStyles.HexNumber);

            if (!hDword.Equals(hDword & 0x7fffffff))
            {
                hDword = hDword & 0x7fffffff;
                sMask = "40000000";
            }

            hDword = hDword >> 1;

            Int32 hResult = hDword | Int32.Parse(sMask, NumberStyles.HexNumber) | Int32.Parse(sSgn, NumberStyles.HexNumber);
            return (string.Format("{0:x}", hResult).ToUpper());
        }

        /// <summary>
        /// Convertit un Float32 IEEE 754 en double
        /// </summary>
        /// <param name="FloatValue">(string) Float32 a convertir</param>
        /// <returns>(double) nombre convertit</returns>
        public static double Float322Double(string FloatValue)
        {
            string BinVal;
            string Signe;
            string Expo;
            string Mant;

            double DecExpo;

            double j;

            string EntPart;
            string FracPart;
            double ValEntPart;
            double ValFracPart;
            double FinalValue;

            if (FloatValue.Equals("80000000") | FloatValue.Equals("00000000"))
            {
                return (0);
            }

            //Conversion en binaire
            BinVal = Hex2Bin(FloatValue);

            //Verfication 32 bits présent
            if (BinVal.Length < 32)
            {
                while (BinVal.Length < 32)
                {
                    BinVal = "0" + BinVal;
                }
            }

            //Lecture du signe, de l'exposant et de la mantisse
            Signe = BinVal.Substring(0, 1);
            Expo = BinVal.Substring(1, 8);
            Mant = BinVal.Substring(9, 23);

            //Calcul de l'exposant
            DecExpo = Bin2Dec(Expo) - 127;

            //Calcul de la valeur decimale
            if (DecExpo > 1) //Valeur finale supérieure à 1
            {
                EntPart = "1" + Mant.Substring(0, (int)DecExpo);
                FracPart = Mant.Substring((int)DecExpo, (int)(23 - DecExpo));

                //Partie entière
                ValEntPart = Bin2Dec(EntPart);

                //Partie decimale
                ValFracPart = 0;
                j = 0.5;
                for (int i = 0; i < FracPart.Length; i++)
                {
                    ValFracPart = ValFracPart + Convert.ToDouble(FracPart.Substring(i, 1)) * j;
                    j = j / 2;
                }
            }
            else //Valeur finale inférieure à 1
            {
                ValEntPart = 0;
                ValFracPart = 0;
                FracPart = "1" + Mant;

                j = 1;
                for (int i = 0; i < FracPart.Length; i++)
                {
                    ValFracPart = ValFracPart + Convert.ToDouble(FracPart.Substring(i, 1)) * j;
                    j = j / 2;
                }

                ValFracPart = ValFracPart * Math.Pow(2, DecExpo);
            }

            FinalValue = ValEntPart + ValFracPart;

            //Affectation du signe
            if (Signe.Equals("1"))
            {
                FinalValue = FinalValue * -1;
            }

            return (FinalValue);

        }

        #endregion

        #region SByte / Decimal

        /// <summary>
        /// Convertit un nombre hexadecimal au format SBYTE (8 bits signé) en décimal
        /// </summary>
        /// <param name="SByteValue">(string) SBYTE à convertir</param>
        /// <returns>(double) Valeur decimale</returns>
        public static double SByte2Dec(string SByteValue)
        {
            double DecVal;

            DecVal = Hex2Dec(SByteValue);

            if (DecVal > 127)
            {
                DecVal = DecVal - 256;
            }

            return (DecVal);
        }

        /// <summary>
        /// Convertit un nombre décimal en hexadecimal au format SBYTE (8 bits signé)
        /// </summary>
        /// <param name="DecValue">(int) Valeur décimale à convertir</param>
        /// <returns>Valeur hexadecimale en SBYTE</returns>
        /// <remarks>
        /// La valeur d'entrée est automatiquement tronqué entre -128 et 127
        /// </remarks>
        public static string Dec2SByte(long DecValue)
        {
            if (DecValue > 127)
            {
                DecValue = 127;
            }

            if (DecValue < -128)
            {
                DecValue = -128;
            }

            if (DecValue >= 0)
            {
                return (Dec2Hex(DecValue));
            }
            else
            {
                return (Dec2Hex(DecValue + 256));
            }

        }

        #endregion

        #region SWord / Decimal

        /// <summary>
        /// Convertit un nombre hexadecimal au format SWORD (16 bits signé) en décimal
        /// </summary>
        /// <param name="SWordValue">(string) SWORD à convertir</param>
        /// <returns>(double) Valeur decimale</returns>
        public static double SWord2Dec(string SWordValue)
        {
            double DecVal;

            DecVal = Hex2Dec(SWordValue);

            if (DecVal > 32767)
            {
                DecVal = DecVal - 65536;
            }

            return (DecVal);
        }

        /// <summary>
        /// Convertit un nombre décimal en hexadecimal au format SWORD (16 bits signé)
        /// </summary>
        /// <param name="DecValue">(int) Valeur décimale à convertir</param>
        /// <returns>Valeur hexadecimale en SWORD</returns>
        /// <remarks>
        /// La valeur d'entrée est automatiquement tronqué entre -32768 et 32767
        /// </remarks>
        public static string Dec2SWord(long DecValue)
        {
            if (DecValue > 32767)
            {
                DecValue = 32767;
            }

            if (DecValue < -32768)
            {
                DecValue = -32768;
            }

            if (DecValue >= 0)
            {
                return (Dec2Hex(DecValue));
            }
            else
            {
                return (Dec2Hex(DecValue + 65536));
            }
        }

        #endregion

        #region SDWord / Decimal

        /// <summary>
        /// Convertit un nombre hexadecimal au format SDWORD (32 bits signé) en décimal
        /// </summary>
        /// <param name="SDWordValue">(string) SDWORD à convertir</param>
        /// <returns>(double) Valeur decimale</returns>
        public static double SDWord2Dec(string SDWordValue)
        {
            double DecVal;

            DecVal = Hex2Dec(SDWordValue);

            if (DecVal > 2147483647)
            {
                DecVal = DecVal - 4294967296;
            }

            return (DecVal);
        }

        /// <summary>
        /// Convertit un nombre décimal en hexadecimal au format SDWORD (32 bits signé)
        /// </summary>
        /// <param name="DecValue">(int) Valeur décimale à convertir</param>
        /// <returns>Valeur hexadecimale en SDWORD</returns>
        /// <remarks>
        /// La valeur d'entrée est automatiquement tronqué entre -2147483648 et 2147483647
        /// </remarks>
        public static string Dec2SDWord(long DecValue)
        {
            if (DecValue > 2147483647)
            {
                DecValue = 2147483647;
            }

            if (DecValue < -2147483648)
            {
                DecValue = -2147483648;
            }

            if (DecValue >= 0)
            {
                return (Dec2Hex(DecValue));
            }
            else
            {
                return (Dec2Hex(DecValue + 4294967296));
            }
        }

        #endregion

        #endregion
    }
}
