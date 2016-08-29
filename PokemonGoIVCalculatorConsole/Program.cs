using System;
using System.Drawing;
using PokemonGoIVCalculator;
using tessnet2;

namespace PokemonGoIVCalculatorConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            var filename =
                @"\\Mac\Home\RiderProjects\PokemonGoIVCalculator\PokemonGoIVCalculator\Resources\Screenshots\Blastoise_20.png";

            //var image = new Bitmap(filename);
            var ocr = new Tesseract();
            //ocr.SetVariable("tessedit_char_whitelist", "0123456789"); // If digit only
            //@"C:\OCRTest\tessdata" contains
            //the language package, without this the method crash and app breaks
            /*ocr.Init(@"C:\OCRTest\tessdata", "eng", true);
            var result = ocr.DoOCR(image, Rectangle.Empty);
            foreach (Word word in result)
                Console.WriteLine("{0} : {1}", word.Confidence, word.Text);
            */
            Console.ReadLine();
        }

        public static void Main___(string[] args)
        {
            Console.WriteLine("Hello");

            /*
            var filename = @"/Users/lundmikkel/RiderProjects/PokemonGoIVCalculator/PokemonGoIVCalculator/Resources/Screenshots/Blastoise_20.jpg";
            /*/
            var filename = @"\\Mac\Home\RiderProjects\PokemonGoIVCalculator\PokemonGoIVCalculator\Resources\Screenshots\Blastoise_20.png";
            //*/

            var imageHandler = new ImageHandler(filename);

            var maxHp = imageHandler.GetMaxHp();
            Console.WriteLine($"Max HP: {maxHp}");

            var family = imageHandler.GetFamily();
            Console.WriteLine($"Family: {family}");

            var cp = imageHandler.GetCp();
            Console.WriteLine($"Raw CP: {cp}");

            Console.ReadKey();
        }

        static void Main_(string[] args)
        {
            var team = Team.Valor;

            Console.WriteLine("Let us try to calculate your Pokémon's individual values! Please enter the following things.");

            string name;
            do
            {
                Console.Write("Nickname: ");
                name = Console.ReadLine();
            } while (!BaseStat.PokemonWithNameExists(name));

            var maxPossibleCp = GetMaxCpFor(name);
            int cp;
            do
            {
                Console.Write("CP: ");
                if (!int.TryParse(Console.ReadLine(), out cp))
                    continue;
            } while (!(10 <= cp && cp <= maxPossibleCp));

            var maxPossibleHp = GetMaxHpFor(name);
            int maxHp;
            do
            {
                Console.Write("Max HP: ");
                if (!int.TryParse(Console.ReadLine(), out maxHp))
                    continue;
            } while (!(10 <= maxHp && maxHp <= maxPossibleHp));

            var maxPossibleLevel = 40;
            float level;
            do
            {
                Console.Write("Level: ");
                // TODO: Fix format?
                if (!float.TryParse(Console.ReadLine(), out level))
                    continue;
            } while (!(1 <= level && level <= maxPossibleLevel));

            var overallRange = PokemonTotalRange.Unknown;
            var bestValues = Value.Unknown;
            var bestValuesRange = IndividualValueRange.Unknown;

            char answer;
            do
            {
                Console.Write("\nWould you like to use the appraisal of your leader? (y/n) ");
                if (!char.TryParse(Console.ReadLine(), out answer))
                    continue;
            } while (answer != 'y' && answer != 'n');

            if (answer == 'y') {

            }

            var id = BaseStat.GetIdFromName(name);

            var pokemon = new Pokemon(
                name,
                id,
                cp,
                maxHp,
                level,
                overallRange,
                bestValues,
                bestValuesRange
            );

            var possibleIndividualValues = pokemon.FindPossibleIndividualValues();

            Console.WriteLine("\nThese are all the possible individual value sets your Pokémon can have:");
            foreach (var individualValues in possibleIndividualValues)
                Console.WriteLine(individualValues);
        }

        private static int GetMaxCpFor(string name) => 4144;
        private static int GetMaxHpFor(string name) => 200;
    }
}


