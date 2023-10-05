using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNews
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region String Interpolition
            string name     = "Ozan Berkay";
            string surname  = "ÖZCAN";
            Console.WriteLine("Merhaba" + name+" "+surname); // klasik concat bağlamı
            string text = string.Format("Merhaba {0} {1}", name, surname);
            Console.WriteLine(text);

            // String interpolation
            Console.WriteLine($"Merhaba { name } - { surname }");
            #endregion

            #region Var Anahtar Kelimesi

            string nameSurname = "Ozan Berkay ÖZCAN";
            Console.WriteLine(nameSurname);

            var job = "Bilgisayar Programcısı";
            job.ToString();
            var category = 1;
            category = 1;
            #endregion

            #region İsimsiz tip kullanımı
            Customer customer = new Customer();
            customer.name = "Test";
            customer.surname = "Test";

            var Ogrenci = new
            {
                numara  = 1,
                isim    = "Cengiz",
                soyisim = "Atilla"
            };

            Console.WriteLine(Ogrenci.isim); // var anahtar sözcüğü ile oluşturduğumuz örneğin tool type'ini okumakta fayda var...
                                             // Çünkü get ve set metotları, yandaki isim keyword'ünün üstüne geldiğinizde görüğünüz
                                             // gibi sadece get'i içermektedir.
            #endregion

            #region Local Function Kullanımı

            int Toplam = Topla(12, 44);
            Console.WriteLine(Toplam); // Topla fonksiyonu class seviyesinde ama Main'in içinde değil!

            int Carpim(int x, int y)
            {
                return x * y;
            }

            int carpim = Carpim(12, 3);
            Console.WriteLine(carpim);

            /*
             * Yukarıdaki gibi bir şeye neden ihtiyaç duyarız ? 
             * Çünkü bazen yazdığımız kodlar uzar ve tekrara düşeriz..
             * Bu şekilde tekrar eden bölümleri sadece o kod bloğunun içinde kullanmak üzere bir local fonksiyona atar
             * ve kullanırız!
             */

            #endregion

            #region Default değer ataması

            int result = Carp(12);      // Yanda gördüğünüz fonksiyon normal şartlarda iki parametre alırken burada sadece bir tane girdik
                                        // Bu demek oluyor ki aslında y parametresinin bir default değeri atanmış 
            Console.WriteLine(result);


            #endregion

            #region Try-Catch When kullanımı 
            try
            {
                // Bu bölümde kodlarımız var
                throw new FormatException();
            }
            catch(FieldAccessException fex)
            {
                Console.WriteLine(fex.Message);
            }
            catch (FormatException fe) when (fe.Message == "Format Hatası") // Buradaki when kullanımı aynı kategoriye sahip iki exception'ı
                                                                            // aynı anda kullanabilmek için koyduğumuz bir ön koşuldur
                                                                            // Bu ön koşul base olandan üstte olmalıdır!
            {
                Console.WriteLine(fe.Message);
            }
            catch (FormatException fe) 
            {
                Console.WriteLine(fe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region Auto Property
            Car car = new Car();
            car.NumberPlate = "34 ABC 11";
            car.brand = "Test";
            // Bunu öğrenmek için Car class'ına gitmen gerekecek!
            #endregion

            #region Tuple Kullanımı
            Tuple<string, string, int, bool, Car, string, string> usingTupple 
                = new Tuple<string, string, int, bool, Car, string, string>
                (
                    "cengiz", "atilla", 34, true, new Car() { }, "İstanbul", "Türkiye"
                ); // Maksimum 8 tane değer alabiliyor şu an fakat 8.item Başka bir tupple daha tanımlamak için kullanıldığından
                   // oraya sadece Tupple ataması yapmak zorundayız aksi taktirde hata verebilir.

            Console.WriteLine(usingTupple.Item1); // Item2 yi ekrana yazdıracak.

            Tuple<string, string> meetingVariables = Meeting();
            Console.WriteLine(meetingVariables);

            var meeting2 = Meeting2();
            Console.WriteLine(meeting2.name);
            Console.WriteLine(meeting2.surname);

            #endregion

            #region Dynamic Kullanımı

            //var value1 = "Cengiz Atilla";     // var anahtar sözcüğü ile herhangi bir tipi değişkene atayabiliyoruz.
            //value1 = 1;                       // fakat bir üst satırda string olarak ayarlandığı için 
                                                // artık ona sadece string ataması yapılır int vb. tipte atama yapılamaz

            dynamic value2 = "Cengiz Atilla";
            value2 = 12;
            value2 = true;
            value2 = new { isim = "cengiz" };

            /*
             * Ne atama yaparsak ona dönüşür
             * Değerin içinden inherit gelen herhangi bir metot yoktur. Çünkü hangi tip olacağı belli değildir.
             * Objeye çok benzer ama tam olarak değildir
             * Her yerde olmasa da bazı durumlarda işe yarayabilir. 
             */

            object o1 = 12; 
            o1.GetType(); // bu şekilde değerin object class'ından miras aldığı metotlara ulaşabiliriz
                          // fakat dynmaic için bu geçerli değildir

            #endregion
        }
        static int Topla(int x, int y)
        {
            //Carp(12, 6);  Görüldüğü gibi hata alınıyor... Çünkü bu bir local function 
            return x + y;
        }
        static int Carp(int x = 1, int y = 1) // Bu şekilde default bir değer ataması yapabiliriz...
                                              // Çağırdığmız bu fonksiyona değer girmemize bile gerek kalmaz...
                                              // Bununla beraber default değer atadığımız parametreden sonra atama yapmadığımız bir başka parametre koyamayız
                                              // Bu atamayı default parametre ataması yağtığımız ilk değişkenden önce yazmalıyız :D *ÖNEMLİ*
        {
            //if (y == 0) y = 1;
            return y * x;
        }
        static Tuple<string, string> Meeting()
        {
            return new Tuple<string, string>("cengiz", "atilla");
        }
        static (string name, string surname) Meeting2() // Bir üst satırdaki Tuple'ın bir başka ve daha kolay yazım şekli
        {
            return ("cengiz", "atilla");
        }
    }
}
