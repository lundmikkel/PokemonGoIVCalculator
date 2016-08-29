using System.Drawing;

namespace PokemonGoIVCalculator
{
    public class ImageHandler
    {
        private string Path { get; }

        private static readonly Rectangle CpArea = new Rectangle(225, 80, 300, 75);
        private static readonly Rectangle HpArea = new Rectangle(185, 695, 375, 50);
        private static readonly Rectangle CandyArea = new Rectangle(300, 965, 400, 40);

        public ImageHandler(string path) {
            Path = path;

            /*AspriseOCR.SetUp();
            Ocr = new AspriseOCR();
            Ocr.StartEngine("eng", AspriseOCR.SPEED_FASTEST);*/
        }

        private string Recognize(Rectangle area) => null; /*Ocr.Recognize(
            Path,
            -1,
            area.X,
            area.Y,
            area.Width,
            area.Height,
            AspriseOCR.RECOGNIZE_TYPE_ALL,
            AspriseOCR.OUTPUT_FORMAT_PLAINTEXT
        );*/

        public int GetMaxHp() => int.Parse(Recognize(HpArea).Split('/')[1]);

        public string GetFamily() => Recognize(CandyArea).Split(' ')[0].ToLower();

        public string GetCp() => Recognize(CpArea);
    }
}