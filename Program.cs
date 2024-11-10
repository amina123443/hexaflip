using System;

namespace hexaflip
{
    internal class Program
    {

        public static string IndextToString(int indext)
        {
            string[] order = { "Y3", "O4", "R8", "B2", "G6", "Y7", "R1", "P5", "B0" };//the side is alocated to it's respected indext, allowing a quick look up using the indext
            return order[indext];
        }
        public static int DirectionIndext(ConsoleKeyInfo input)
        {
            /*
            ConsoleKeyInfo consoleKeyInfo;
            consoleKeyInfo = Console.ReadKey(true);
            int indext = (int)consoleKeyInfo.Key;
            Console.WriteLine(indext);
            */
            //this section was used to get the unicode of the charaters when capalised, regardless if the input was upper or lower case

            //A=65
            //B=66
            //C=67
            //therefore if we minus the unicode by 65, our valid inputs are
            //0,1,2 which is our indext for our second dimention array repesenting the direction where a=0,b=1 and c=2
            int indext = (int)input.Key;
            indext = indext - 65;
            if ((indext<0)||(indext>2))
            {
                return -1;//the result was not 0,1,2 therefore the input was invalid
            }
            return indext;//else return the result
                    
        }
        static void Main(string[] args)
        {
            int[,] grapth = {//the grapth is created using the adjacent list where the first dimention indext repesent the starting side, the indext of the second dimention is a,b,c where a=0,b=1 and c=2, and the values are the sides where -1 are dead ends
                { 3,1,-1},//Y3--> {B2,a} {O4,b}
                {2,-1,-1 },//O4--> {R8,a}
                {-1,-1,0 },//R8-->{Y3,c}
                {6,4,-1 },//B2-->{R1,a} {G6,b}
                {5,-1,-1},//G6-->{Y7,a}
                {-1,-1,3 },//Y7-->{B2,c}
                {0,7,-1},//R1-->{Y3,a} {P5,b}
                { 8,-1,-1 },//P5--> {B0,a}
                {-1,-1,6 },//B0-->{R1,c}
                };
            Console.WriteLine("to move when asked, press the a key to move in the 'a' direction\npress the b key to move in the 'b' direction\npress the c key to move in the 'c' direction\n");//instruction on how to move
            int start = 0;//we start at Y3
            while(true)//this program ends till the user manualy close the console
            {
                Console.WriteLine("you are at " + IndextToString(start) + " which direction do you want to go,a b or c");//tells the user the current location
                bool moved = false;//to tell if the user moved to a new location so we can tell them the new location
                while (!moved)//loops till the user moved
                {
                    ConsoleKeyInfo user = Console.ReadKey(true);//reads the input of the user which is the key they pressed
                    int indext = DirectionIndext(user);//converts the input into idext
                    if (indext == -1)//if the result was an invalid indext
                    {
                        continue;//we retun to line 58 for a new input, nothing happening is a good way to tell they pressed the wrong button
                    }
                    Console.WriteLine("you went in direction " + user.Key.ToString().ToLower());//tells the user the direction they went, the Tostring().Tolower() is there to lower caps the user.key which is caps, I don't know why but it means that regardless of the input being in cap or not, the unicode returned will be the same
                    int end = grapth[start, indext];//gets the end location from the grapth
                    if (end == -1 )//if we hit a dead end, we tell the user that
                    {
                        Console.WriteLine("hm, you can't seams to go through that direction in this side and you are still at "+ IndextToString(start) + ", maybe go in a diffrent direction\n");
                    }
                    else
                    {
                        start = end;//update the new locaion
                        Console.WriteLine("you found yourself in a diffrent side\n");//tell them that
                        moved = true;//update the bool to tell the user the new location
                    }
                }
            }
           


            
        }
    }
}
