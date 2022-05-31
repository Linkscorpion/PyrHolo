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
        Bitmap[] m_img;
        PictureBox m_pbox;
        Thread threadBc;
        bool m_startvar;
        int m_time_speed;
        string m_dossier;

        // Initialisation de la fenêtre principale 
        public Form1()
        {
            InitializeComponent();
            m_startvar = false;
            m_dossier = Application.StartupPath + "\\Image";
            m_time_speed = 1000;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            m_pbox = new PictureBox();
            m_pbox.Location = new Point(0, 0);
            
            m_pbox.Visible = false;
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
                    
                    
                    // Déclaration variable
                    string temp = "*.jpg *.png *.jpeg *.bmp";
                    string[] ext = temp.Split(' ');
                    string[] lst_img;
                    List<string> lst = new List<string>();

                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    m_pbox.Visible = true;
                    m_pbox.SetBounds(0, 0, ClientSize.Width, ClientSize.Height);
                    this.Controls.Add(m_pbox);
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
                                lst_img = Directory.GetFiles(m_dossier, extension, SearchOption.TopDirectoryOnly);
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
                            lst_img = Directory.GetFiles(m_dossier, extension, SearchOption.TopDirectoryOnly);
                            foreach (string name in lst_img)
                            {
                                lst.Add(name);
                            }
                        }
                    }

                    m_startvar = true;


                    m_img = new Bitmap[lst.Count];

                    int i = 0;
                    foreach (String name in lst)
                    {
                        m_img[i] = new Bitmap(name);
                        m_img[i] = Affichage2D.Resize_Image(m_img[i], ClientSize.Height / 3, ClientSize.Width / 3);
                        Bitmap imG = Affichage2D.Rotation_Image(m_img[i], 90);
                        Bitmap imH = Affichage2D.Rotation_Image(m_img[i], 180);
                        Bitmap imD = Affichage2D.Rotation_Image(m_img[i], 270);
                        m_img[i] = Affichage2D.Fusion_Image(imH, imD, m_img[i], imG, ClientSize.Width, ClientSize.Height);
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
                if (i >= m_img.Length) i = 0;
                m_pbox.Image = m_img[i];
                Thread.Sleep(m_time_speed);
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
            else if (e.KeyCode == Keys.B)
            {
                m_time_speed += 100;
            }
            else if (e.KeyCode == Keys.N)
            {
                if (m_time_speed <= 100)
                    m_time_speed = 17;
                else
                    m_time_speed -= 100;
            }
            else if (e.KeyCode == Keys.O)
            {
                m_dossier = Application.StartupPath + "\\Optique";
                LectureImage();
            }
            else if (e.KeyCode == Keys.I)
            {
                m_dossier = Application.StartupPath + "\\Image";
                LectureImage();
            }
            else if (e.KeyCode == Keys.V)
            {
                m_dossier = Application.StartupPath + "\\Vision";
                LectureImage();
            }
            else if (e.KeyCode == Keys.F)
            {
                m_dossier = Application.StartupPath + "\\Video";
                m_time_speed = 17;
                LectureImage();
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
