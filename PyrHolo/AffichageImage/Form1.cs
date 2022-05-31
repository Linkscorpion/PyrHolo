using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffichageImage
{
    public partial class Form1 : Form
    {
        //Variable globale
        Bitmap[] img;
        PictureBox pbox;
        Thread threadBc;
        bool m_startvar;

        // Initialisation de la fenêtre principale 
        public Form1()
        {
            InitializeComponent();
            m_startvar = false;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pbox = new PictureBox();
            pbox.Location = new Point(0, 0);
            
            pbox.Visible = false;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            threadBc = new Thread(() => BoucleImage());

        }

        // Ouverture des images
        private void btOuvrir_Click(object sender, EventArgs e)
        {
            btStart.Hide();
            btOuvrir.Hide();
            LectureImage();
        }

        // Lecture des images et démarrage du thread associé
        private void LectureImage()
        {
            if (threadBc.ThreadState != ThreadState.Aborted)
                threadBc.Abort();
            
                try{
                    // Mettre un dossier Image à l'endroit où se trouve le fichier .exe ( par défaut dans le dossier debug )
                    string dossier = Application.StartupPath + "\\Image";
                    
                    // Déclaration variable
                    string temp = "*.jpg *.png *.jpeg *.bmp";
                    string[] ext = temp.Split(' ');
                    string[] lst_img;
                    List<string> lst = new List<string>();

                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    pbox.Visible = true;
                    pbox.SetBounds(0, 0, ClientSize.Width, ClientSize.Height);
                    this.Controls.Add(pbox);
                    if(m_startvar == false)
                        if (dlOpFolder.ShowDialog() == DialogResult.OK)
                        {
                            foreach (string extension in ext)
                            {

                                //ajoute chaque chemin d'image à la liste de string
                                lst_img = Directory.GetFiles(dlOpFolder.SelectedPath, extension, SearchOption.TopDirectoryOnly);
                                foreach (string name in lst_img)
                                {
                                    lst.Add(name);
                                }
                            }
                        }
                        else
                        {
                            foreach (string extension in ext)
                            {
                                lst_img = Directory.GetFiles(dossier, extension, SearchOption.TopDirectoryOnly);
                                foreach (string name in lst_img)
                                {
                                    lst.Add(name);
                                }
                            }
                        }
                    else
                    {
                        foreach (string extension in ext)
                        {
                            lst_img = Directory.GetFiles(dossier, extension, SearchOption.TopDirectoryOnly);
                            foreach (string name in lst_img)
                            {
                                lst.Add(name);
                            }
                        }
                    }

                    img = new Bitmap[lst.Count];

                    int i = 0;
                    foreach (String name in lst)
                    {
                        img[i] = new Bitmap(name);
                        img[i] = Affichage2D.Resize_Image(img[i], ClientSize.Height / 3, ClientSize.Width / 3);
                        Bitmap imG = Affichage2D.Rotation_Image(img[i], 90);
                        Bitmap imH = Affichage2D.Rotation_Image(img[i], 180);
                        Bitmap imD = Affichage2D.Rotation_Image(img[i], 270);
                        img[i] = Affichage2D.Fusion_Image(imH, imD, img[i], imG, ClientSize.Width, ClientSize.Height);
                        i++;
                    }

                    threadBc = new Thread(() => BoucleImage());
                    threadBc.Start();

                    


                }
                catch(Exception excpt) { MessageBox.Show(excpt.ToString()); }
            
        }

        // Boucle sur l'affichage des images
        private void BoucleImage()
        {
            int i = 0;
            while (1 == 1)
            {
                if (i >= img.Length) i = 0;
                pbox.Image = img[i];
                Thread.Sleep(1000);
                i++;
            }
        }

        // Action lorsque qu'une touche du clavier est enfoncé
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Environment.Exit(Environment.ExitCode);
            else if (e.KeyCode == Keys.A)
                LectureImage();
            else if (e.KeyCode == Keys.P)
            {
                ThreadState th = threadBc.ThreadState;
                if (threadBc.ThreadState == ThreadState.Running || threadBc.ThreadState == ThreadState.WaitSleepJoin)
                    threadBc.Suspend();
                else if (threadBc.ThreadState == ThreadState.Suspended)
                    threadBc.Resume();
                
            }

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            m_startvar = true;
            btStart.Hide();
            btOuvrir.Hide();
            LectureImage();
        }
    }
}
