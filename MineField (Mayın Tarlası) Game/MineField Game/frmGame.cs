using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;//www.gorselprogramlama.com
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MineField_Game
{
    public partial class frmGame : Form
    {
        public FormOnizleme frmonz;


        public frmGame()
        {
            InitializeComponent();
            frmonz = new FormOnizleme();
        }


        int totalField = 0;
        bool state = false;
        private void CreateField(int height, int width) //parametre olarak aldığı uzunlukta butonları oluşturur //hoca 5x5 istediği için ikiside 5 olarak gönderildi.
        {
            int X = 1, Y = 1; //butona sol ve üst boşluk için for içerisinde ayarlandı.
            int btnNameIndis = 0;
            //5x5 lik matrisin butonlarını oluşturur
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    //oluşturulacak butonun özellikleri buradan ayarlanıyor.
                    //name ve click özellikleri değiştirilmemeli. diğerleri değiştirilebilir
                    Button btn = new Button();//www.gorselprogramlama.com
                    btn.Left = X; btn.Top = Y;
                    btn.Height = 25; btn.Width = 25;
                    btn.Name = "btnField" + btnNameIndis; //butonun isminin sonuna sıra numarası da ekleniyor. Tüm butonlar için ortak  tıklanma metodu var hangi metoda tıklandığı bu sıra numarası ile öğrenilecek aşağıda daha iyi anlayacaksınız.
                    //btn.Text = btnNameIndis.ToString();
                    btn.TabIndex = btnNameIndis;
                    btn.BackColor = Color.RoyalBlue;
                    btn.FlatStyle = FlatStyle.Popup;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Click += new EventHandler(MineField_Click);

                    btn.MouseEnter += new EventHandler(MineField_MouseEnter); //butonun üzerine tıklandığında renk değişmesi için
                    btn.MouseLeave += new EventHandler(MineField_MouseLeave); //mouse üzerine geldiğinde renk değişmesi için bu ikisi silinebilir
                    pnlField.Controls.Add(btn); //buton burada panelin içine ekleniyo her buton tek tek for döngüsü içinde eklendi.
                    X += btn.Width + 1;
                    btnNameIndis++;
                }
                Y += 25 + 1;
                X = 1;
            }
            totalField = height * width;
            //lblFloor.Text = height + "x" + width;
            //lblMine.Text = totalMine.ToString();

            //butonların olduğu panelin boyutu ayarlanıyor tasarım kısmında elle manuel girip bunlar silinebilir
            pnlField.Height = 26 * height + 1;
            pnlField.Width = 26 * width + 1;

            //formun boyutu ayarlanıyor tasarım kısmında elle manuel girip bunlar silinebilir
            this.Height = pnlField.Height + pnlField.Top + 29;
            this.Width = pnlField.Width + pnlField.Left + 7;

            PutMine(); //mayınları yerleştirecek metot çağırılıyor.
        }

        private void AddPreview() //önizleme formu için
        {
            int X = 1, Y = 1;
            int height = 5;
            int width = 5;

            int btnNameIndis = 0;
            //burada önizleme formu için butonlar oluşturuluyor
            //özellikleri buradan değiştirilebilir. name değiştirilmemeli.
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Button btn = new Button();
                    btn.Left = X; btn.Top = Y;
                    btn.Height = 25; btn.Width = 25;
                    btn.Name = "btnField" + btnNameIndis;
                    btn.TabIndex = btnNameIndis;
                    btn.BackColor = Color.RoyalBlue;
                    btn.FlatStyle = FlatStyle.Popup;
                    FormOnizleme.panelonlz.Controls.Add(btn);
                    X += btn.Width + 1;
                    if (Array.IndexOf(Mines, btnNameIndis) != -1) //arkaplanı mayınlı ise kırmızı //buradaki Mines mayınların numarası listesi aşağıda nasıl doldurulduğunu göreceksiniz.
                        btn.BackColor = Color.Red;
                    else
                        btn.BackColor = Color.Green; // değil ise yeşil olur.

                    btnNameIndis++;
                }
                Y += 25 + 1;
                X = 1;
            }

            // ön izleme formunun boyutu buradan yapılabilir veya tasarım kısmından statik olarak ayarlanabilir.
            //FormOnizleme.panelonlz.Height = 26 * height + 1;
            //FormOnizleme.panelonlz.Width = 26 * width + 1;
            //frmonz.Height = pnlField.Height + pnlField.Top + 29;
            //frmonz.Width = pnlField.Width + pnlField.Left + 7;

            int btnNameIndis2 = 0;

            //burada oluşturulan butonların numaraları belirleniyo. yani komşu butonlarda ki mayın sayısı
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Button btn = (Button)FormOnizleme.panelonlz.Controls.Find("btnField" + btnNameIndis2, true)[0];
                    btn.Text = PutNumber(btnNameIndis2).ToString(); //aşağıda putnumber butonu var ona kaçıncı buton olduğu bilgisi gönderiliyor.
                    btnNameIndis2++;
                }

            }
            //ön izleme panelinin boyutu buradan ayarlanabilir veya tasarım kısmından statik olarak ayarlanır.
            FormOnizleme.panelonlz.Height = 26 * height + 1;
            FormOnizleme.panelonlz.Width = 26 * width + 1;

        }

        private void DeleteField() //burda oyun başlatılmadan önce paneller temizlenir butonlar silinir
        {
            for (int i = 0; i < totalField; i++)
            {
                pnlField.Controls.Find("btnField" + i, true)[0].Dispose(); //oyun ekranı 
                FormOnizleme.panelonlz.Controls.Find("btnField" + i, true)[0].Dispose(); //önizleme ekranı
            }
        }

        int totalMine = 0;
        Random r = new Random();
        int[] Mines;
        private void PutMine() //mayınlar burada oluşturuluyor üstte aşağı inince göreceksiniz yazmıştım
        {
            //total mine kullanıcıdan aldığımız mayın sayısı yani kaç tane mayın olacağı
            //tüm butonların içerisine rasgele mayınlar yerleştiriliyor ve bu mayının yerleri Mines isminde ki diziye atılıyor.
            Mines = new int[totalMine];
            for (int i = 0; i < totalMine; i++)
            {
                int rnd = r.Next(0, totalField);
                while (Array.IndexOf(Mines, rnd) != -1)
                {
                    rnd = r.Next(0, totalField);
                }
                Mines[i] = rnd;
            }
        }

        private void OpenAllMine() //oyunu kaybettiğinde veya süresi dolduğunda oyun biter ve kullanıcıya mayın yerleri gösterilir
        {
            for (int i = 0; i < totalField; i++)
            {
                Button btn = (Button)pnlField.Controls.Find("btnField" + i, true)[0];
                int NameIndis = Convert.ToInt32(btn.Name.Remove(0, 8));
                if (Array.IndexOf(Mines, NameIndis) != -1)
                {
                    btn.BackgroundImage = Properties.Resources.mine;
                }
            }
        }


        private int PutNumber(int indis)
        {
            int value = 0;
            int line = 0;

            if (totalMine == 9)
            {
                line = 10;
            }
            else
            {
                line = 16;
            }
            //tıklanan butonun konumuna göre etrafında ki buton sayıları değişir
            //örneğin ;
            //eğer tıklanan buton sol üst köşedeyse etrafında 3 buton olyuor
            //eğer üst ortadaysa etrafında 5 buton oluyor
            //eğer kenarda değil ortadaysa etrafında 8 buton oluyor 
            //o yüzden önce butonun nerede olduğu öğrenilir

            if (indis % FieldLine == 0) // sol tarafta ise
            {
                if (indis == (FieldLine * line) - FieldLine) // sol üst köşe
                {
                    if (MineControl(indis - FieldLine)) value++;
                    if (MineControl((indis - FieldLine) + 1)) value++;
                }
                else if (indis == 0) //sol alt köşe
                {
                    if (MineControl(indis + FieldLine)) value++;
                    if (MineControl((indis + FieldLine) + 1)) value++;
                }
                else //sol orta
                {
                    if (MineControl(indis - FieldLine)) value++;
                    if (MineControl((indis - FieldLine) + 1)) value++;
                    if (MineControl(indis + FieldLine)) value++;
                    if (MineControl((indis + FieldLine) + 1)) value++;
                }
                if (MineControl(indis + 1)) value++;
            }
            else if (indis >= 0 && indis < FieldLine) // üstte ise
            {
                if (indis == (FieldLine - 1)) //üst köşede ise
                {
                    if (MineControl(indis - 1)) value++;
                    if (MineControl(indis + FieldLine)) value++;
                    if (MineControl(indis + FieldLine - 1)) value++;
                }
                else //üst ortada ise
                {
                    if (MineControl(indis - 1)) value++;
                    if (MineControl(indis + 1)) value++;
                    if (MineControl(indis + FieldLine)) value++;
                    if (MineControl(indis + FieldLine - 1)) value++;
                    if (MineControl(indis + FieldLine + 1)) value++;
                }
            }
            else if (indis % FieldLine == (FieldLine - 1) && (indis - (FieldLine - 1)) / FieldLine <= (line - 1)) // sağ dikey
            {   
                if (indis == ((FieldLine * line) - 1)) //sağ üst köşe veya sağ alt köşe
                {
                    if (MineControl(indis - FieldLine)) value++;
                    if (MineControl(indis - FieldLine - 1)) value++;
                    if (MineControl(indis - 1)) value++;
                }
                else //sağ ortada ise
                {
                    if (MineControl(indis - 1)) value++;
                    if (MineControl(indis - FieldLine)) value++;
                    if (MineControl(indis + FieldLine)) value++;
                    if (MineControl(indis - FieldLine - 1)) value++;
                    if (MineControl(indis + FieldLine - 1)) value++;
                }
            }
            else if (indis >= (FieldLine * line) - FieldLine && indis < (FieldLine * line)) // alt
            {
                if (MineControl(indis - FieldLine)) value++;
                if (MineControl(indis - FieldLine - 1)) value++;
                if (MineControl(indis - FieldLine + 1)) value++;
                if (MineControl(indis - 1)) value++;
                if (MineControl(indis + 1)) value++;
            }
            else // orta kısım
            {
                if (MineControl(indis - FieldLine)) value++;
                if (MineControl(indis - FieldLine - 1)) value++;
                if (MineControl(indis - FieldLine + 1)) value++;
                if (MineControl(indis + FieldLine)) value++;
                if (MineControl(indis + FieldLine - 1)) value++;
                if (MineControl(indis + FieldLine + 1)) value++;
                if (MineControl(indis - 1)) value++;
                if (MineControl(indis + 1)) value++;
            }
            //etrafında mayın varsa value 1 arttılır en son kaç tane varsa toplamı döndürülür
            return value;
        }


        private bool MineControl(int value) // buraya butonun numarası gönderiliyor mayınlı mı değil mi kontrol ediliyor
        {
            if (Array.IndexOf(Mines, value) != -1) //mayın listesinde eğer parametreden gelen butonun no su varsa 1 yoksa -1 olur
            {
                return true;
            }
            return false;
        }

        void MineField_MouseLeave(object sender, EventArgs e) //mouse üzrine geldiğinde butonların renk değiştirmesi için metot. bu özelliği silenler bunuda silsin isteyen rengi değiştirsin
        {
            if (((Button)sender).BackColor != Color.Chartreuse)
            {
                ((Button)sender).BackColor = Color.RoyalBlue;
            }
        }

        void MineField_MouseEnter(object sender, EventArgs e) // üzrine tıklandığında butonların renk değiştirmesi için metot. özelliği silenler bunuda silsin isteyen rengi değiştirsin
        {
            if (((Button)sender).BackColor != Color.Chartreuse)
            {
                ((Button)sender).BackColor = Color.DodgerBlue;
            }
        }

        private void MineField_Click(object sender, EventArgs e) //oyunda ki her bir buton için tıklandığında çalışacak metot
        {
            //her metot için ayrı ayrı tıklanma fonksiyonu yazılmaz sender yöntemi ile 1 metot tüm butonlar için kullanilabilir.

            //tıklanan butonun kaçıncı sırada olduğu isminin sonunda tutuluyor. örneğin btnField2 veya btnField10 gibi sonunda ki sayısı sıra numarası olarak ayarlandı
            int NameIndis = Convert.ToInt32((((Button)sender).Name).Remove(0, 8)); 
            if (Array.IndexOf(Mines, NameIndis) != -1) //mayın ise
            {
                ((Button)sender).BackgroundImage = Properties.Resources.mine; //mayına tıklandıysa o butonun arkaplanına mayın resmi geliyor
                Finish(); 
            }
            else
            {
                totaltime = fixedtotaltime; //eğer mayına tıklanmadıysa tıklanma süresi sıfırlanıyor 
                ((Button)sender).BackColor = Color.Chartreuse;
                ((Button)sender).Text = PutNumber(NameIndis).ToString();
                ((Button)sender).Enabled = false; //butona tekrar tıklatmıyo
                ControlToWin(); //ve kazanıp kazanmadığı kontrol ediliyor.
            }
        }
        private void Finish()
        {
            //((Button)sender).BackColor = Color.Red;
            //((Button)sender).BackgroundImage = Properties.Resources.mine;
            timer1.Stop(); //süre durur
            state = false; //oyun durumu oyun bitti yani false olur
            OpenAllMine(); //oyun bittiği için mayınların yerini gösterecek buton
            MessageBox.Show(" Oyunu kaybettiniz.", "");
            pnlField.Enabled = false;
        }

        private void ControlToWin()
        {
            //oyunu kazanıp kazanmadığını kontrol eder 
            bool win = true;
            for (int i = 0; i < totalField; i++)
            {
                Button btn = (Button)(pnlField.Controls.Find("btnField" + i, true)[0]);
                if (btn.Enabled)
                {
                    if (!MineControl(Convert.ToInt32(btn.Name.Remove(0, 8))))
                    {
                        win = false;
                        break;
                    }
                }
            }
            if (win)
            {
                timer1.Stop();
                MessageBox.Show("Tebrikler, Oyunu kazandınız. Bütün mayınları tespit ettiniz.", "Kazandınız");
                OpenAllMine();
                pnlField.Enabled = false;
                state = false;
            }
        }

        
        int FieldLine = 0;



        private void Form1_Load(object sender, EventArgs e) //arkadaşlar bunu silmeyin içerisi boşda olsa dursun. silerseniz tasarım ekranı bozulur
        {
            //formn boyutu buradan ayarlanabilir veya tasarım kısmından
            //this.Size = new Size(267, 339);
            //pnlField.Size = new Size(261, 261);
        }

        private void buttonbuttonStart_Click(object sender, EventArgs e)
        {
            if (state) //eğer mevcut oyun var ise yeniden başlansın mı diye sorar. State de oyunun durumu tutuluyor . true olursa oynanıyor false oyun bitti demek
            {
                DialogResult secenek = MessageBox.Show("Mevcut oyun iptal edili yeni oyun başlatılacaktır onaylıyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {
                    frmonz.Show(); //ön izleme formunu görünür yapar
                    totalMine = (int)NumericMayinSayisi.Value; //kullanıcıdan toplam mayın sayısını alır
                    FieldLine = 5; //matrisin 5x5 olacağı için 5 olarak ayarlandı
                    DeleteField(); //panelin içindeki butonlar temizlendi
                    CreateField(5, 5); //oyun formundaki butonlar oluşturuldu
                    pnlField.Enabled = true; //panelin tıklama özelliği aktif edildi
                    AddPreview(); //önizleme formunda ki gösterilecek butonlar ayarlandı
                    totaltime = (int)NumericSure.Value; //süre kullanıcıdan alındı. timer da düşürülecek
                    fixedtotaltime = (int)NumericSure.Value; //süre her butona tıklandığında belirlenen sayıya dönecek bu yüzden bu sabit tutuldu ki buna döndürülsün
                    timer1.Start();
                }
                else if (secenek == DialogResult.No) //burda birşey çalışmasna gerek yok mesajbox kapanıyo kendi kaldığı yerden devam
                {
                    //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
                }
            }
            else //eğer mevcut oyun yoksa burada onay sorusu çıkmayacak direk başlatılacak
            {
                state = true;
                frmonz.Show();
                totalMine = (int)NumericMayinSayisi.Value;
                FieldLine = 5;
                DeleteField();
                CreateField(5, 5);
                pnlField.Enabled = true;
                AddPreview();
                totaltime = (int)NumericSure.Value;
                fixedtotaltime = (int)NumericSure.Value;
                timer1.Start();
            }
        }
        int totaltime = 0;
        int fixedtotaltime = 0;
        private void timer1_Tick(object sender, EventArgs e) // süre tutan sayaç. 1 saniyede 1 kere tetikleniyo ve her saniyede burada ki kodlar çalışıyor
        {
            labelkalansure.Text = "Kalan Süre = " + totaltime.ToString() + " sn";
            if (totaltime > 0) 
                totaltime--;
            else //süresi dolduysa
                Finish();
        }
    }
}
