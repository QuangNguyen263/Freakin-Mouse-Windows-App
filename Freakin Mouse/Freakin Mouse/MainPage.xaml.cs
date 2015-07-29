using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;


namespace Freakin_Mouse
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer dt, dt2;
        double left = 35;
        double top = 119;
        double leftC = 1240;
        double topC = 130;
        double leftC2 = 35;
        double topC2 = 490;
        double leftCheese = 100;
        double topCheese = 100;
        int score = 0;
        double speed = 10;
        int timez, timez2, timez3;
        bool gup = false, gdown = false, gleft = false, gright = false;
        bool cup = true, cdown = false, cleft = false, cright = false;
        bool cup2 = true, cdown2 = false, cleft2 = false, cright2 = false;
        bool stt = false;
        Random rd;
        BitmapImage bi3 = new BitmapImage();
        public MainPage()
        {
            this.InitializeComponent();
            rd = new Random();
            Canvas.SetLeft(Mouse, left);
            Canvas.SetTop(Mouse, top);
            Canvas.SetZIndex(Mouse, 2);
            Canvas.SetZIndex(Cheese, 1);
            createCheese();
            mr.Volume = 20;
        }
        public void start()
        {
            gup = false;
            gdown = false;
            gleft = false;
            gright = true;
            //+++++++++++++create Ghost navigation++++++++++
            upGhost();
            createdt();
            timez = 800;
            timez2 = 0;
            timez3 = 0;
            createdt2();
            btplay.Visibility = Visibility.Collapsed;
            btplayagain.Visibility = Visibility.Visible;
            bdmain.Visibility = Visibility.Collapsed;
        }
        public void createdt()
        {
            dt = new DispatcherTimer();
            dt.Tick += new EventHandler<Object>(dt_Tick);
            dt.Interval = new TimeSpan(10);
            dt.Start();
        }
        public void createdt2()
        {
            dt2 = new DispatcherTimer();
            dt2.Tick += new EventHandler<Object>(dt2_Tick);
            dt2.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dt2.Start();
        }
        public void getImageUI(Image im, string url)
        {
            bi3 = new BitmapImage(new Uri(im.BaseUri, url));
        }

        public void time()
        {
            timez = rd.Next(200, 500);
        }
        public void changetime()
        {
            timez2 = timez / 100;
            timez3 = timez % 100;
        }
        public void createCheese()
        {
        ctcheese:
            leftCheese = rd.Next(-35, 1360);
            topCheese = rd.Next(50, 680);
            Canvas.SetTop(Cheese, topCheese);
            Canvas.SetLeft(Cheese, leftCheese);
            if (consillionMatrix(Cheese))
            {
                goto ctcheese;
            }
        }
        public bool consillionMouseAnother(Image at)
        {
            Rect r1 = new Rect(Canvas.GetLeft(Mouse), Canvas.GetTop(Mouse), Mouse.Width, Mouse.Height);
            Rect r2 = new Rect(Canvas.GetLeft(at), Canvas.GetTop(at), at.Width, at.Height);
            r1.Intersect(r2);

            if (!r1.IsEmpty)
            {
                createCheese();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void gameover(string a)
        {
            mr.Stop();
            eat.Stop();
            die.Play();
            dt.Stop();
            dt2.Stop();
            god.Text = score + "";
            tbo.Text = a;
            bdmain2.Visibility = Visibility.Visible;
        }
        public void restart()
        {
            bdmain2.Visibility = Visibility.Collapsed;
            Ghost2.Visibility = Visibility.Collapsed;
            left = 35;
            top = 119;
            leftC = 1240;
            topC = 130;
            leftC2 = 35;
            topC2 = 700;
            Canvas.SetLeft(Mouse, left);
            Canvas.SetTop(Mouse, top);
            Canvas.SetLeft(Ghost, leftC);
            Canvas.SetTop(Ghost, topC);
            Canvas.SetLeft(Ghost2, leftC2);
            Canvas.SetTop(Ghost2, topC2);
            getImageUI(Mouse, "Assets/MouseRight.png");
            Mouse.Source = bi3;
            speed = sltd.Value / 5;
            score = 0;
            tbsp.Text = 40 + "";
            lblPointnumber.Text = score.ToString();
            createCheese();
            gup = false;
            gdown = false;
            gleft = false;
            gright = true;
            stt = false;
            checkMouse();
            createdt();
            die.Stop();
            timez = 500;
            createdt2();
            sltd.Value = 40;
        }
        public void createGhost()
        {

            int m = rd.Next(1, 4);
            switch (m)
            {
                case 1:
                    cup = true;
                    cdown = false;
                    cleft = false;
                    cright = false;
                    break;
                case 2:
                    cup = false;
                    cdown = true;
                    cleft = false;
                    cright = false;
                    break;
                case 3:
                    cup = false;
                    cdown = false;
                    cleft = true;
                    cright = false;
                    break;
                case 4:
                    cup = false;
                    cdown = false;
                    cleft = false;
                    cright = true;
                    break;
            }
        }
        public void createGhost2()
        {

            int m = rd.Next(1, 4);
            switch (m)
            {
                case 1:
                    cup2 = true;
                    cdown2 = false;
                    cleft2 = false;
                    cright2 = false;
                    break;
                case 2:
                    cup2 = false;
                    cdown2 = true;
                    cleft2 = false;
                    cright2 = false;
                    break;
                case 3:
                    cup2 = false;
                    cdown2 = false;
                    cleft2 = true;
                    cright2 = false;
                    break;
                case 4:
                    cup2 = false;
                    cdown2 = false;
                    cleft2 = false;
                    cright2 = true;
                    break;
            }
        }
        public bool consillionMatrix(Image a)
        {
            Rect rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
            Rect rt1 = new Rect(Canvas.GetLeft(rec1), Canvas.GetTop(rec1), rec1.Width, rec1.Height);
            rt.Intersect(rt1);
            if (!rt.IsEmpty)
            {
                return true;
            }
            else
            {
                rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                rt1 = new Rect(Canvas.GetLeft(rec2), Canvas.GetTop(rec2), rec2.Width, rec2.Height);
                rt.Intersect(rt1);
                if (!rt.IsEmpty)
                {
                    return true;
                }
                else
                {
                    rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                    rt1 = new Rect(Canvas.GetLeft(rec3), Canvas.GetTop(rec3), rec3.Width, rec3.Height);
                    rt.Intersect(rt1);
                    if (!rt.IsEmpty)
                    {
                        return true;
                    }
                    else
                    {
                        rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                        rt1 = new Rect(Canvas.GetLeft(rec4), Canvas.GetTop(rec4), rec4.Width, rec4.Height);
                        rt.Intersect(rt1);
                        if (!rt.IsEmpty)
                        {
                            return true;
                        }
                        else
                        {
                            rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                            rt1 = new Rect(Canvas.GetLeft(rec5), Canvas.GetTop(rec5), rec5.Width, rec5.Height);
                            rt.Intersect(rt1);
                            if (!rt.IsEmpty)
                            {
                                return true;
                            }
                            else
                            {
                                rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                rt1 = new Rect(Canvas.GetLeft(rec6), Canvas.GetTop(rec6), rec6.Width, rec6.Height);
                                rt.Intersect(rt1);
                                if (!rt.IsEmpty)
                                {
                                    return true;
                                }
                                else
                                {


                                    rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                    rt1 = new Rect(Canvas.GetLeft(rec7), Canvas.GetTop(rec7), rec7.Width, rec7.Height);
                                    rt.Intersect(rt1);
                                    if (!rt.IsEmpty)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                        rt1 = new Rect(Canvas.GetLeft(rec8), Canvas.GetTop(rec8), rec8.Width, rec8.Height);
                                        rt.Intersect(rt1);
                                        if (!rt.IsEmpty)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                            rt1 = new Rect(Canvas.GetLeft(rec9), Canvas.GetTop(rec9), rec9.Width, rec9.Height);
                                            rt.Intersect(rt1);
                                            if (!rt.IsEmpty)
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                rt1 = new Rect(Canvas.GetLeft(rec10), Canvas.GetTop(rec10), rec10.Width, rec10.Height);
                                                rt.Intersect(rt1);
                                                if (!rt.IsEmpty)
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                    rt1 = new Rect(Canvas.GetLeft(rec11), Canvas.GetTop(rec11), rec11.Width, rec11.Height);
                                                    rt.Intersect(rt1);
                                                    if (!rt.IsEmpty)
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                        rt1 = new Rect(Canvas.GetLeft(rec12), Canvas.GetTop(rec12), rec12.Width, rec12.Height);
                                                        rt.Intersect(rt1);
                                                        if (!rt.IsEmpty)
                                                        {
                                                            return true;
                                                        }
                                                        else
                                                        {
                                                            rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                            rt1 = new Rect(Canvas.GetLeft(rec13), Canvas.GetTop(rec13), rec13.Width, rec13.Height);
                                                            rt.Intersect(rt1);
                                                            if (!rt.IsEmpty)
                                                            {
                                                                return true;
                                                            }
                                                            else
                                                            {
                                                                rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                rt1 = new Rect(Canvas.GetLeft(rec14), Canvas.GetTop(rec14), rec14.Width, rec14.Height);
                                                                rt.Intersect(rt1);
                                                                if (!rt.IsEmpty)
                                                                {
                                                                    return true;
                                                                }
                                                                else
                                                                {
                                                                    rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                    rt1 = new Rect(Canvas.GetLeft(rec15), Canvas.GetTop(rec15), rec15.Width, rec15.Height);
                                                                    rt.Intersect(rt1);
                                                                    if (!rt.IsEmpty)
                                                                    {
                                                                        return true;
                                                                    }
                                                                    else
                                                                    {
                                                                        rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                        rt1 = new Rect(Canvas.GetLeft(rec16), Canvas.GetTop(rec16), rec16.Width, rec16.Height);
                                                                        rt.Intersect(rt1);
                                                                        if (!rt.IsEmpty)
                                                                        {
                                                                            return true;
                                                                        }
                                                                        else
                                                                        {
                                                                            rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                            rt1 = new Rect(Canvas.GetLeft(rec17), Canvas.GetTop(rec17), rec17.Width, rec17.Height);
                                                                            rt.Intersect(rt1);
                                                                            if (!rt.IsEmpty)
                                                                            {
                                                                                return true;
                                                                            }
                                                                            else
                                                                            {
                                                                                rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                rt1 = new Rect(Canvas.GetLeft(rec18), Canvas.GetTop(rec18), rec18.Width, rec18.Height);
                                                                                rt.Intersect(rt1);
                                                                                if (!rt.IsEmpty)
                                                                                {
                                                                                    return true;
                                                                                }
                                                                                else
                                                                                {
                                                                                    rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                    rt1 = new Rect(Canvas.GetLeft(rec19), Canvas.GetTop(rec19), rec19.Width, rec19.Height);
                                                                                    rt.Intersect(rt1);
                                                                                    if (!rt.IsEmpty)
                                                                                    {
                                                                                        return true;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                        rt1 = new Rect(Canvas.GetLeft(rec20), Canvas.GetTop(rec20), rec20.Width, rec20.Height);
                                                                                        rt.Intersect(rt1);
                                                                                        if (!rt.IsEmpty)
                                                                                        {
                                                                                            return true;
                                                                                        }
                                                                                        else
                                                                                        {

                                                                                            rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                            rt1 = new Rect(Canvas.GetLeft(rec25), Canvas.GetTop(rec25), rec25.Width, rec25.Height);
                                                                                            rt.Intersect(rt1);
                                                                                            if (!rt.IsEmpty)
                                                                                            {
                                                                                                return true;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                rt1 = new Rect(Canvas.GetLeft(rec26), Canvas.GetTop(rec26), rec26.Width, rec26.Height);
                                                                                                rt.Intersect(rt1);
                                                                                                if (!rt.IsEmpty)
                                                                                                {
                                                                                                    return true;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                    rt1 = new Rect(Canvas.GetLeft(rec27), Canvas.GetTop(rec27), rec27.Width, rec27.Height);
                                                                                                    rt.Intersect(rt1);
                                                                                                    if (!rt.IsEmpty)
                                                                                                    {
                                                                                                        return true;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                        rt1 = new Rect(Canvas.GetLeft(rec28), Canvas.GetTop(rec28), rec28.Width, rec28.Height);
                                                                                                        rt.Intersect(rt1);
                                                                                                        if (!rt.IsEmpty)
                                                                                                        {
                                                                                                            return true;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                            rt1 = new Rect(Canvas.GetLeft(rec29), Canvas.GetTop(rec29), rec29.Width, rec29.Height);
                                                                                                            rt.Intersect(rt1);
                                                                                                            if (!rt.IsEmpty)
                                                                                                            {
                                                                                                                return true;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                rt1 = new Rect(Canvas.GetLeft(rec30), Canvas.GetTop(rec30), rec30.Width, rec30.Height);
                                                                                                                rt.Intersect(rt1);
                                                                                                                if (!rt.IsEmpty)
                                                                                                                {
                                                                                                                    return true;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                    rt1 = new Rect(Canvas.GetLeft(rec31), Canvas.GetTop(rec31), rec31.Width, rec31.Height);
                                                                                                                    rt.Intersect(rt1);
                                                                                                                    if (!rt.IsEmpty)
                                                                                                                    {
                                                                                                                        return true;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                        rt1 = new Rect(Canvas.GetLeft(rec32), Canvas.GetTop(rec32), rec32.Width, rec32.Height);
                                                                                                                        rt.Intersect(rt1);
                                                                                                                        if (!rt.IsEmpty)
                                                                                                                        {
                                                                                                                            return true;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                            rt1 = new Rect(Canvas.GetLeft(rec33), Canvas.GetTop(rec33), rec33.Width, rec33.Height);
                                                                                                                            rt.Intersect(rt1);
                                                                                                                            if (!rt.IsEmpty)
                                                                                                                            {
                                                                                                                                return true;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                                rt1 = new Rect(Canvas.GetLeft(rec34), Canvas.GetTop(rec34), rec34.Width, rec34.Height);
                                                                                                                                rt.Intersect(rt1);
                                                                                                                                if (!rt.IsEmpty)
                                                                                                                                {
                                                                                                                                    return true;
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                                    rt1 = new Rect(Canvas.GetLeft(rec35), Canvas.GetTop(rec35), rec35.Width, rec35.Height);
                                                                                                                                    rt.Intersect(rt1);
                                                                                                                                    if (!rt.IsEmpty)
                                                                                                                                    {
                                                                                                                                        return true;
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                                        rt1 = new Rect(Canvas.GetLeft(rec36), Canvas.GetTop(rec36), rec6.Width, rec36.Height);
                                                                                                                                        rt.Intersect(rt1);
                                                                                                                                        if (!rt.IsEmpty)
                                                                                                                                        {
                                                                                                                                            return true;
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                                            rt1 = new Rect(Canvas.GetLeft(rec37), Canvas.GetTop(rec37), rec37.Width, rec37.Height);
                                                                                                                                            rt.Intersect(rt1);
                                                                                                                                            if (!rt.IsEmpty)
                                                                                                                                            {
                                                                                                                                                return true;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                                                rt1 = new Rect(Canvas.GetLeft(rec38), Canvas.GetTop(rec38), rec38.Width, rec38.Height);
                                                                                                                                                rt.Intersect(rt1);
                                                                                                                                                if (!rt.IsEmpty)
                                                                                                                                                {
                                                                                                                                                    return true;
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                                                    rt1 = new Rect(Canvas.GetLeft(rec39), Canvas.GetTop(rec39), rec39.Width, rec39.Height);
                                                                                                                                                    rt.Intersect(rt1);
                                                                                                                                                    if (!rt.IsEmpty)
                                                                                                                                                    {
                                                                                                                                                        return true;
                                                                                                                                                    }
                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        rt = new Rect(Canvas.GetLeft(a), Canvas.GetTop(a), a.Width, a.Height);
                                                                                                                                                        rt1 = new Rect(Canvas.GetLeft(rec40), Canvas.GetTop(rec40), rec40.Width, rec40.Height);
                                                                                                                                                        rt.Intersect(rt1);
                                                                                                                                                        if (!rt.IsEmpty)
                                                                                                                                                        {
                                                                                                                                                            return true;
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            return false;
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }

                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void checkMouse()
        {
            if (Canvas.GetTop(Mouse) <= 44 && gup)
            {
                top = 680;
                Canvas.SetTop(Mouse, top);
            }
            if (Canvas.GetLeft(Mouse) <= -41 && gleft)
            {
                left = 1365;
                Canvas.SetLeft(Mouse, left);
            }
            if (Canvas.GetTop(Mouse) >= 640 && gdown)
            {
                top = 44;
                Canvas.SetTop(Mouse, top);
            }
            if (Canvas.GetLeft(Mouse) >= 1365 && gright)
            {
                left = -41;
                Canvas.SetLeft(Mouse, left);
            }
        }
        public void checkGhost()
        {
            if (Canvas.GetTop(Ghost) <= 50 && cup)
            {
                topC = 640;
                Canvas.SetTop(Ghost, topC);
            }
            if (Canvas.GetLeft(Ghost) <= -20 && cleft)
            {
                leftC = 1320;
                Canvas.SetLeft(Ghost, leftC);
            }
            if (Canvas.GetTop(Ghost) >= 640 && cdown)
            {
                topC = 50;
                Canvas.SetTop(Ghost, topC);
            }
            if (Canvas.GetLeft(Ghost) >= 1320 && cright)
            {
                leftC = -20;
                Canvas.SetLeft(Ghost, leftC);
            }
        }
        public void checkGhost2()
        {
            if (Canvas.GetTop(Ghost2) <= 50 && cup2)
            {
                topC2 = 640;
                Canvas.SetTop(Ghost2, topC2);
            }
            if (Canvas.GetLeft(Ghost2) <= -20 && cleft2)
            {
                leftC2 = 1320;
                Canvas.SetLeft(Ghost2, leftC2);
            }
            if (Canvas.GetTop(Ghost2) >= 640 && cdown2)
            {
                topC2 = 50;
                Canvas.SetTop(Ghost2, topC2);
            }
            if (Canvas.GetLeft(Ghost2) >= 1320 && cright2)
            {
                leftC2 = -20;
                Canvas.SetLeft(Ghost2, leftC2);
            }
        }
        public void upmouse()
        {
            top = top - speed;
            Mouse.Height = 50;
            Mouse.Width = 40;
            if (stt)
            {
                getImageUI(Mouse, "Assets/MouseUp2.png");

                Mouse.Source = bi3;
            }
            if (stt == false)
            {
                getImageUI(Mouse, "Assets/MouseUp3.png");

                Mouse.Source = bi3;
            }
            Canvas.SetTop(Mouse, top);
        }
        public void downmouse()
        {
            top = top + speed;
            Mouse.Height = 50;
            Mouse.Width = 40;
            if (stt)
            {
                getImageUI(Mouse, "Assets/MouseDown2.png");

                Mouse.Source = bi3;
            }
            if (stt == false)
            {
                getImageUI(Mouse, "Assets/MouseDown3.png");
                Mouse.Source = bi3;
            }
            Canvas.SetTop(Mouse, top);
        }
        public void rightmouse()
        {
            left = left + speed;
            Mouse.Height = 40;
            Mouse.Width = 50;
            if (stt)
            {
                getImageUI(Mouse, "Assets/MouseRight2.png");
                Mouse.Source = bi3;
            }
            if (stt == false)
            {
                getImageUI(Mouse, "Assets/MouseRight3.png");
                Mouse.Source = bi3;
            }
            Canvas.SetLeft(Mouse, left);
        }
        public void leftmouse()
        {
            left = left - speed;
            Mouse.Height = 40;
            Mouse.Width = 50;
            if (stt)
            {
                getImageUI(Mouse, "Assets/MouseLeft2.png");
                Mouse.Source = bi3;
            }
            if (stt == false)
            {
                getImageUI(Mouse, "Assets/MouseLeft3.png");
                Mouse.Source = bi3;
            }
            Canvas.SetLeft(Mouse, left);
        }
        //+++++++++++set Ghost navigation++++++++++
        public void upGhost()
        {
            topC = topC - speed;
            Canvas.SetTop(Ghost, topC);
        }
        public void downGhost()
        {
            topC = topC + speed;
            Canvas.SetTop(Ghost, topC);
        }
        public void rightGhost()
        {
            leftC = leftC + speed;
            Canvas.SetLeft(Ghost, leftC);
        }
        public void leftGhost()
        {
            leftC = leftC - speed;
            Canvas.SetLeft(Ghost, leftC);
        }
        //+++++++++++set Ghost2 navigation++++++++++
        public void upGhost2()
        {
            topC2 = topC2 - speed;
            Canvas.SetTop(Ghost2, topC2);
        }
        public void downGhost2()
        {
            topC2 = topC2 + speed;
            Canvas.SetTop(Ghost2, topC2);
        }
        public void rightGhost2()
        {
            leftC2 = leftC2 + speed;
            Canvas.SetLeft(Ghost2, leftC2);
        }
        public void leftGhost2()
        {
            leftC2 = leftC2 - speed;
            Canvas.SetLeft(Ghost2, leftC2);
        }
        private void btnup_Click(object sender, RoutedEventArgs e)
        {
            gup = true;
            gdown = false;
            gleft = false;
            gright = false;
        }

        private void btnright_Click(object sender, RoutedEventArgs e)
        {
            gup = false;
            gdown = false;
            gleft = false;
            gright = true;
        }

        private void btndown_Click(object sender, RoutedEventArgs e)
        {
            gup = false;
            gdown = true;
            gleft = false;
            gright = false;
        }

        private void btnleft_Click(object sender, RoutedEventArgs ei)
        {
            gup = false;
            gdown = false;
            gleft = true;
            gright = false;
        }

        private void dt_Tick(object sender, Object e)
        {
            speed = sltd.Value / 5;
            tbsp.Text = sltd.Value + "";
            if (score >= 3)
            {
                Ghost2.Visibility = Visibility.Visible;
                if (consillionMatrix(Ghost2))
                {
                    createGhost2();
                }

                if (cup2)
                {
                    upGhost2();
                }
                if (cdown2)
                {
                    downGhost2();
                }
                if (cleft2)
                {
                    leftGhost2();
                }
                if (cright2)
                {
                    rightGhost2();
                }
                checkGhost2();
            }
            if (consillionMatrix(Ghost))
            {
                createGhost();
            }
            if (cup)
            {
                upGhost();
            }
            if (cdown)
            {
                downGhost();
            }
            if (cleft)
            {
                leftGhost();
            }
            if (cright)
            {
                rightGhost();
            }
            checkGhost();
            mr.Play();
            checkMouse();
            lblPointnumber.Text = score.ToString();
            if (stt)
            {
                stt = false;
            }
            else
            {
                stt = true;
            }
            if (gup)
            {
                upmouse();
            }
            if (gdown)
            {
                downmouse();
            }
            if (gleft)
            {
                leftmouse();
            }
            if (gright)
            {
                rightmouse();
            }
            if (consillionMatrix(Mouse))
            {
                gameover("Game Over!");
            }
            else
            {
                if (consillionMouseAnother(Ghost))
                {
                    gameover("Game Over!");
                }
                else
                {
                    if (consillionMouseAnother(Ghost2))
                    {
                        gameover("Game Over!");
                    }
                    else
                    {
                        if (consillionMouseAnother(Cheese))
                        {
                            score = score + 1;
                            mr.Stop();
                            eat.Play();
                            dt2.Stop();
                            time();
                            dt2.Start();
                        }
                        else
                        {
                            mr.Play();
                        }
                    }
                }
            }
        }
        private void dt2_Tick(object sender, Object e)
        {
            if (timez == 0)
            {
                gameover("Time Over!");
            }
            else
            {
                timez = timez - 1;
                changetime();
                lblTimenumber.Text = timez2 + ": " + timez3;
            }
        }
        private void btplay_Click(object sender, RoutedEventArgs e)
        {
            start();
        }
        private void btplayagain_Click(object sender, RoutedEventArgs e)
        {
            restart();
        }
        private void Window_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Right)
            {
                gup = false;
                gdown = false;
                gleft = false;
                gright = true;
            }
            if (e.Key == VirtualKey.Left)
            {
                gup = false;
                gdown = false;
                gleft = true;
                gright = false;
            }
            if (e.Key == VirtualKey.Up)
            {
                gup = true;
                gdown = false;
                gleft = false;
                gright = false;
            }
            if (e.Key == VirtualKey.Down)
            {
                gup = false;
                gdown = true;
                gleft = false;
                gright = false;
            }
            if (e.Key == VirtualKey.Z)
            {
                sltd.Value = sltd.Value - 1;
            }
            if (e.Key == VirtualKey.X)
            {
                sltd.Value = sltd.Value + 1;
            }
        }

        private void Page_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
           
        }
    }
}
