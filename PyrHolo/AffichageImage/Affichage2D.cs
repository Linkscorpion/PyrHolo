using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace AffichageImage
{
    class Affichage2D
    {

        public void Partage_Ecran()
        {

        }

        // Permet de redécouper l'image en fonction des paramètres de hauteurs et de largeur souhaité
        public static Bitmap Resize_Image(Bitmap imgToResize, int hauteur, int largeur)
        {
            Size size = new Size(largeur, hauteur);
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            //Calcul du redimenssionement 

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            //Nouvelle Largeur 

            int destWidth = (int)(sourceWidth * nPercent);

            //Nouvelle Hauteur 

            int destHeight = (int)(sourceHeight * nPercent);

            //
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Definition de la nouvelle image 

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }

        // Rotation de l'image selon un angle souhaité 90/180/270
        public static Bitmap Rotation_Image(Bitmap im, int angle)
        {
            Bitmap temp = new Bitmap(im);
            if(angle == 90)
                temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (angle == 180)
                temp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (angle == 270)
                temp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return temp;
        }

        // Fusion de l'ensemble des images en fonction de la taille de la fenêtre
        public static Bitmap Fusion_Image(Bitmap imBas, Bitmap imDroite, Bitmap imHaut, Bitmap imGauche,int tailleFenX, int tailleFenY)
        {
            int centreX = tailleFenX / 2;
            int centreY = tailleFenY / 2;
            int difSomPyr = tailleFenY - 2 * imBas.Height; // taille entre le sommet et l'image

            Bitmap imgFus;
            if (tailleFenY > tailleFenX)
                imgFus = new Bitmap(tailleFenX, tailleFenY);
            else
                imgFus = new Bitmap(tailleFenX, tailleFenY);


            Graphics g = Graphics.FromImage(imgFus);
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, tailleFenX, tailleFenY));
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Definition de la nouvelle image 
            g.DrawImage(imHaut, centreX - (imBas.Width / 2), tailleFenY - imBas.Height, imBas.Width, imBas.Height);
            g.DrawImage(imDroite, centreX + difSomPyr, centreY - (imDroite.Height / 2), imDroite.Width, imDroite.Height);
            g.DrawImage(imBas, centreX - (imHaut.Width / 2), 0, imHaut.Width, imHaut.Height);
            g.DrawImage(imGauche, centreX - imGauche.Width - difSomPyr, centreY - (imGauche.Height / 2), imGauche.Width, imGauche.Height);
            g.Dispose();


            return imgFus;
        }


    }
}
