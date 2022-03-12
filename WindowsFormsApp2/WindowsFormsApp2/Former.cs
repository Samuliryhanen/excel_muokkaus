using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WindowsFormsApp2
{
    /// <summary>
    /// Class for parsing text
    /// </summary>
    internal class Former
    {
        string[,] textArray = new string[,] { };
        string[,] returnArray = new string[,] { };
        

        public Former(string[,] textArray,int endi,int endy)
        {
            this.textArray = textArray;
            this.returnArray = ParseArray(textArray,endi, endy);
        }
        
        public string[,] GetResult()
        {
            return returnArray;
        }
        /// <summary>
        /// Parse a 2d-array which has 4 columns into a 
        /// 2 column 2d-array
        /// </summary>
        /// <param name="textArray"></param>
        /// <param name="endi"></param>
        /// <param name="endy"></param>
        /// <returns></returns>
        public string[,] ParseArray(string[,] textArray, int endi, int endy)
        {
            string[,] array = new string[endy,2]; //TODO: dynaamiseksi 

            for(int i =0; i< endy; i++)
            {
                string[] num = new string[4];
                for(int j = 0; j < endi; j++)// luetaan 4 solua jokaiselta riviltä
                {
                    num[j] = textArray[i, j];
                }
                int sum = int.Parse(num[0])+ int.Parse(num[1]); 
                array[i, 1] = sum.ToString();

                string text = ParseSentence(num); // tekstisolun käsittely
                array[i, 0] = text;
            }
            return array;
        }
        /// <summary>
        /// Käsittelee lauseet 
        /// </summary>
        /// <param name="num"> Rivikohtainen taulukko jokaisesta solusta </param>
        /// <returns></returns>

        private string ParseSentence(string[] num)//TODO: tämäkin dynaamiseksi
        {
            string[] words = num[num.Length-1].Split(' ');
            string returnString ="";
            for (int i = 0; i < words.Length; i++)
            {//switch casella olisi varmaan tullut järkevämpi, mutta  menköön nyt
                if (words[i].Equals("on"))
                {
                    returnString+= words[i] + " " + num[1].ToString() + " ";
                    continue;
                }
                if (words[i].Equals("päivänä"))
                {
                    returnString += num[0].ToString() + ". " + words[i] + " ";
                    continue;
                }
                if (i == words.Length-1)
                {
                    returnString += words[i] + " eli " + num[0] + "." + num[2];
                    continue;
                }
                else
                {
                    returnString += words[i] + " ";
                }
            }
            return returnString;
        }
    }
}
