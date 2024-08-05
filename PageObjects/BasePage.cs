using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Drawing;
using YapePrueba2.Utils;
using System;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;

namespace YapePrueba2.PageObjects
{
    public class BasePage
    {
        //--------------------------
        //Elementos Modal ¡Conexion perdida!
        //--------------------------
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text='Cancelar']")]
        private IWebElement botonCancelar;
        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup[1]/android.widget.TextView")] private IWebElement botonCancelarScanner;

        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout")]
        private IWebElement barraDeNotificaciones;
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[contains(@content-desc,'Wi-Fi')]")]
        private IWebElement botonWifi;


        //--------------------------
        //Elementos para dar permisos
        //--------------------------
        [FindsBy(How = How.Id, Using = "com.android.permissioncontroller:id/permission_allow_foreground_only_button")]
        private IWebElement botonWhileUseApp;
        [FindsBy(How = How.Id, Using = "com.android.permissioncontroller:id/permission_allow_one_time_button")]
        private IWebElement botonOnlyThisTime;
        [FindsBy(How = How.Id, Using = "com.android.permissioncontroller:id/permission_deny_button")]
        private IWebElement botonDontAllow;
        [FindsBy(How = How.Id, Using = "com.android.permissioncontroller:id/permission_allow_button")]
        private IWebElement botonPermitir;

        //--------------------------
        //Elementos de la camara
        //--------------------------
        [FindsBy(How = How.Id, Using = "android:id/content")]
        private IWebElement camara;
        [FindsBy(How = How.Id, Using = "com.android.camera:id/shutter_button")]
        private IWebElement tomarFoto;
        [FindsBy(How = How.Id, Using = "com.android.camera:id/done_button")]
        private IWebElement aceptarFotoTomada;
        [FindsBy(How = How.Id, Using = "com.realplazago.app:id/menu_crop")]
        private IWebElement aceptarFotoCortada;

        //--------------------------
        //Elementos de modal Compartir
        //--------------------------
        [FindsBy(How = How.Id, Using = "android:id/content")]
        private IWebElement modalCompartirAndroid;


        public AndroidDriver<AppiumWebElement> Driver;
        public WebDriverWait _wait;
        public ITouchAction action;
        public bool isPREPROD;
        public bool banner;

        public BasePage(AndroidDriver<AppiumWebElement> driver)
        {
            Driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            _wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            action = new TouchAction(driver);
            PageFactory.InitElements(driver, this);
        }


        public void HacerScrollEn(int xm, int ym, int cantidadPixeles, bool abajo)
        {
            Console.WriteLine(xm);
            Console.WriteLine(ym);
            cantidadPixeles = abajo ? cantidadPixeles : (-1) * cantidadPixeles;
            Console.WriteLine(cantidadPixeles);
            action.Press(xm, ym).Wait(200).MoveTo(xm, ym + cantidadPixeles).Release().Perform();
        }

        internal void ToggleWifi()
        {
            Esperar(2);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C adb shell cmd -w wifi set-wifi-enabled disabled";
            process.StartInfo = startInfo;
            process.Start();
        }

        internal void PrenderWifi()
        {
            Esperar(1);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C adb shell cmd -w wifi set-wifi-enabled enabled";
            process.StartInfo = startInfo;
            process.Start();
        }

        internal void ApagarInternetYCancelar()
        {
            ToggleWifi();
            Esperar(2);
            if (Visualiza("Cancelar"))
            {
                Click(botonCancelar);
            }
        }

        public bool Visualiza(string mensaje) => Visualiza("*", "text", mensaje);

        public bool VisualizaByID(string id)
        {
            try
            {
                Esperar(Driver.FindElementById(id));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool VisualizaTextView(string mensaje)
        {
            try
            {
                Esperar(Driver.FindElementByXPath("//android.widget.TextView[@text='" + mensaje + "']"));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Visualiza(string elemento,string atributo,string valor)
        {
            try
            {
                Esperar(Driver.FindElementByXPath("//"+ elemento + "[@"+atributo+"='" + valor + "']"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Click(string elemento, string atributo, string valor)
        {
            Click(Driver.FindElementByXPath("//" + elemento + "[@" + atributo + "='" + valor + "']"));
        }

        public bool VisualizaEditText(string mensaje)
        {
            try
            {
                Esperar(Driver.FindElementByXPath("//android.widget.EditText[@text='" + mensaje + "']"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Llenar(string e, string mensaje)
        {
            Esperar(Driver.FindElementByXPath("//android.widget.TextView[@text='" + e + "']"));
            Driver.FindElementByXPath("//android.widget.TextView[@text='" + e + "']").SendKeys(mensaje);
        }

        public void Llenar(IWebElement e, string mensaje)
        {
            Esperar(e);
            e.SendKeys(mensaje);
        }

        public void Llenar(string e, string mensaje, bool contains)
        {
            Esperar(1);
            if (contains)
            {
                Esperar(Driver.FindElementByXPath("//android.widget.TextView[contains(@text,'" + e + "')]"));
                Driver.FindElementByXPath("//android.widget.TextView[contains(@text,'" + e + "')]").SendKeys(mensaje);
            }
            else
            {
                Esperar(Driver.FindElementByXPath("//android.widget.TextView[@text='" + e + "']"));
                Driver.FindElementByXPath("//android.widget.TextView[@text='" + e + "']").SendKeys(mensaje);
            }
        }

        public void Click(string mensaje)
        {
            Esperar(Driver.FindElementByXPath("//android.widget.TextView[@text='" + mensaje + "']"));
            Click(Driver.FindElementByXPath("//android.widget.TextView[@text='" + mensaje + "']"));
        }

        public void Click(IWebElement e)
        {
            _wait.Until(d => { return e.Displayed; });
            Thread.Sleep(500);
            e.Click();
            Thread.Sleep(500);
        }

        public void Click(int x, int y) => action.Tap(x, y).Perform();

        public void Click(IWebElement e, int x, int y)
        {
            _wait.Until(d => { return e.Displayed; });
            string[] bounds = GetBounds(e);
            int x0 = int.Parse(bounds[0]);
            int y0 = int.Parse(bounds[1]);
            Click(x0 + x, y0 + y);
        }

        public void Click(IWebElement e, int x, int y, bool desdeEsquinaInferiorDerecha)
        {
            if (desdeEsquinaInferiorDerecha)
            {
                _wait.Until(d => { return e.Displayed; });
                string[] bounds = GetBounds(e);
                int xF = int.Parse(bounds[2]);
                int yF = int.Parse(bounds[3]);
                Click(xF - x, yF - y);
            }
        }
        public int ClickAny(IList<IWebElement> wes)
        {
            Random random = new();
            int i = random.Next(0, wes.Count);
            Click(wes[i]);
            return i;
        }
        
        public IWebElement GetAny(IList<IWebElement> wes)
        {
            Random random = new();
            int i = random.Next(0, wes.Count);
            return wes[i];
        }

        public IWebElement GetAnyExceptLast(IList<IWebElement> wes)
        {
            Random random = new();
            int i = random.Next(0, wes.Count-1);
            return wes[i];
        }

        public bool SeMuestra(IWebElement e)
        {
            try
            {
                _wait.Until(d => { return e.Displayed; });
                //Thread.Sleep(500);
                return true;
            }
            catch
            {
                //Console.WriteLine("NO SE MUESTRA EL ELEMENTO \n" + ex.ToString());
                return false;
            }
        }

        public void Esperar(IWebElement e) => _wait.Until(d => { return e.Displayed; });

        public void Esperar(int t) => Thread.Sleep(t * 1000);
        public void Esperar(double t) => Thread.Sleep(((int)(t * 1000)));

        public bool SeMuestra(IList<IWebElement> l)
        {
            bool seMuestraLista = true;
            foreach (IWebElement ele in l)
            {
                if (SeMuestra(ele) == false)
                {
                    return false;
                };
            }
            return seMuestraLista;
        }

        public void ScrollHastaEncontrarTexto(string t)
        {
            while (!Visualiza(t))
            {
                HacerScroll(200);
            }

            //Driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textMatches(\"" + t + "\").instance(0))");
        }

        public void HacerScrollEn(IWebElement e, int cantidadPixeles, bool abajo)
        {
            string[] bounds = GetBounds(e);
            int xm = (int.Parse(bounds[2])+int.Parse(bounds[0]))/2;
            int ym = (int.Parse(bounds[3])+int.Parse(bounds[1]))/2;
            cantidadPixeles = abajo ? cantidadPixeles : (-1)*cantidadPixeles;
            //Console.WriteLine(xm);
            //Console.WriteLine(ym);
            //Console.WriteLine(cantidadPixeles);
            action.Press(xm,ym).Wait(200).MoveTo(xm, ym+cantidadPixeles).Release().Perform();
            action.Cancel();
        }

        public void HacerScrollEn(int x, int y, int dx, int dy)
        {
            action.Press(x, y).Wait(500).MoveTo(x+dx, y+dy).Release().Perform();
            action.Cancel();
        }


        public void HacerScroll(int n)
        {
            System.Drawing.Size t = Driver.Manage().Window.Size;
            int x = t.Width / 2;
            int y = t.Height / 2;
            int dx = 0;
            int dy = n*(-1);
            //Console.WriteLine("Dimensiones: " + x + " " + y);
            HacerScrollEn(x, y, dx, dy);
        }

        public void HacerScroll()
        {
            HacerScroll(250);
        }

        public void Submit()
        {
            Dictionary<string, string> d = new()
            {
                ["action"] = "search"
            };
            Driver.ExecuteScript("mobile: performEditorAction", d);
        }

        public Color GetColor(IWebElement e, int x, int y)
        {
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
            byte[] byteBuffer = Convert.FromBase64String(ss.AsBase64EncodedString);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);
            memoryStream.Position = 0;
            Bitmap bmpReturn = (Bitmap)Image.FromStream(memoryStream);
            memoryStream.Close();
            Color c = bmpReturn.GetPixel(e.Location.X + x, e.Location.Y + y);
            return c;
        }

        public Color GetColor(IWebElement e)
        {
            string[] numbers = GetBounds(e);
            int x = (int.Parse(numbers[2]) - int.Parse(numbers[0])) / 2;
            int y = (int.Parse(numbers[3]) - int.Parse(numbers[1])) / 2;
            return GetColor(e, x, y);
        }

        public Color GetColor(string msj)
        {
            IWebElement e = Driver.FindElementByXPath("//android.widget.TextView[@text='" + msj + "']");
            return GetColor(e);
        }

        public Color GetColor(string msj, int x, int y)
        {
            IWebElement e = Driver.FindElementByXPath("//android.widget.TextView[@text='" + msj + "']");
            return GetColor(e, x, y);
        }

        public bool NecesitaPermiso() => SeMuestra(botonOnlyThisTime);

        public void darPermisoMientrasSeUsaAPP() => Click(botonWhileUseApp);
        public void darPermiso() => Click(botonPermitir);
        internal void NoDarPermisoCalendario() => Click(botonDontAllow);

        internal bool VisualizaCamara() => SeMuestra(camara);
        public void EsperarColorEnElemento(IWebElement e, Color color)
        {
            Thread.Sleep(500);
            _wait.Until(d => { return GetColor(e).R == color.R && GetColor(e).G == color.G && GetColor(e).B == color.B; });
        }

        public void Retroceder() => Driver.Navigate().Back();

        public void ClickCentroDeLaScreen() => action.Tap(Driver.Manage().Window.Size.Width / 2, Driver.Manage().Window.Size.Height / 2, 2).Perform();

        internal void LimpiarPortapapeles() => Driver.SetClipboardText("", "plaintext");

        internal string GetPortapapeles() => Driver.GetClipboardText();

        internal bool VisualizaModalCompartirAndroid() => SeMuestra(modalCompartirAndroid);

        internal void TomarFoto() => Click(tomarFoto);

        internal void AceptarFoto() => Click(aceptarFotoTomada);

        internal void AceptarFotoCortada() => Click(aceptarFotoCortada);

        internal void OcultarTeclado() => Driver.HideKeyboard();

        public string[] GetBounds(IWebElement e)
        {
            char[] delimiterChars = { ']', '[', ',' };
            return e.GetAttribute("bounds").Split(delimiterChars).Where(val => val.Length != 0).ToArray();
        }

        public string GetContentDesc(IWebElement e) => e.GetAttribute("content-desc");
    }
}