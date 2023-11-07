using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ObservingEmailOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SendEmail2();
        }
        // Udemy videodaki hocanın anlattığı kod
        static void SendEmail(string Receiver, string Topic, string contents)
        {
            Encoding encoding = Encoding.GetEncoding("windows-1254"); // Türkçe karakter için windows-1254 kullanıyoruz...

            MailAddress To1 = new MailAddress("f.turan352@hotmail.com", "Fatma Turan", encoding); // Kime gideceğini belittik. 
            MailAddress MailFrom = new MailAddress("ozanberkay34@gmail.com", "Mail Bilgilendirme", encoding); // Kimden gideceği...
            MailMessage mailMessage = new MailMessage();  
            mailMessage.From = MailFrom;
            mailMessage.To.Add("f.turan352@hotmail.com");
            mailMessage.To.Add(To1);

            // mailMessage.CC.Add(""); Email alan kişi bu liste içerisinde tanımlı olan kişi veya kişileri görebilir.
            // mailMessage.Bcc.Add(""); Bu alanda kişi eklenen kişileri göremez...

            mailMessage.Subject = Topic;    // Konu
            mailMessage.Body = contents;    // İçerik

            mailMessage.IsBodyHtml = true;// Bu şekilde gönderdiğimiz mesajın içeriği HTML şablon şeklinde olur demiş oluruz.

            

            
            SmtpClient smtpMail = new SmtpClient("mail.cengizatilla.com", 587); // Port numarası standart kullanımda 587'ye çevrilmiştir.
                                                                                // Ama 25 olarak da deneyebilirsiniz eğer şirketinizin
                                                                                // Excahange sunucusu üzerinden gönderim yapacaksanız...

            smtpMail.Credentials = new System.Net.NetworkCredential("kampanya@cengizatilla.com" ,"Wv8b2Z1n"); // Kullanıcı adı ve şifre bilgileri

            smtpMail.EnableSsl = false;  // SSL üzerinden gitmiyorsa bunu false yapabiliriz...

            smtpMail.Send(mailMessage);

        }
        // Gmail STMP ile kendi yaptığım kod
        static void SendEmail2()
        {
            
            try
            {
                // Gmail hesap bilgileri
                string username = "ozcanozanberkay@gmail.com";
                string password = "itsc lxvp avrg inee"; // Google App Şifresi
                // SMTP istemci oluşturma ve ayarlama
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true, // SSL kullan
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(username, password)
                };
                

                // Gönderici ve alıcı e-posta adresleri
                string fromEmail = "ozcanozanberkay@gmail.com";
                string toEmail = "ozanberkay34@gmail.com";

                // E-posta ileti oluşturma
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = "Test E-postası";
                mail.Body = "Bu bir test e-postasıdır.";

                

                // E-posta iletilerini gönderme
                smtp.Send(mail);
                Console.WriteLine("E-posta gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
            }
        }

        // ilk kod çalışmıyor o zaten videoyu öğrenme amaçlı yazdığımız kod idi ama ikinci kod yani SendEmail2() çalışıyor...
        /*
         * ikinci kodun çalışması için yapılacak adımlar ... 
         * 
         * 1. ilk önce öneri olarak FAKE bir hesap açın google üzerinden
         * 2. sonra hesap ayarlarından 2 adımlı doğrulamayı etkinleştirin...
         * 3. bütün güvenlik aşamalarını aktif ettikten sonra (mail , telefon) ki bunlar sizin güvenliğiniz için önemlidir.
         *    2 adımlı doğrulama seçeneğine geri gidin ve en altta "UYGULAMA ŞİFRELERİ" diye bir bölüm var. Buradan bir şifre alın...
         *    şifreyi almak için bir konu başlığı girin örneğin ben C# Mail Uygulaması yazdım. Sonra size pop-up içinde bir şifre 
         *    bloğu gelecek onu kopyalayın ve yukarıda password değişkenin içine kopyalayın... Bunun dışında tabi ki yukarıda 
         *    gönderici ve alıcı maili değiştirebilrsiniz. İsterseniz kendi mailinizden bana bile gönderebilirsiniz ama çok istek atmayın
         *    :D
         * 4. Bütün bunları yaptıktan sonra aslında her şey hazırdır...
         * Notlar: 
         * Bu kodlar hakkında bilgi vermek istiyorum.Gmail SMTP sunucusunun port adresi 465 veya 587'dir.
         * Gönderme aşamaları yukarıdaki gibidir ve incelemenizi aynı zamanda da debug etmenizi tavsiye ederim.
         * var smtp adındaki değişkenin içerisindekiler önemlidir. bunları da gözden geçirip araştırmanızı tavsiye ederim.
         * Bu kodlar 7.11.2023 tarihinde yazıldı belki bunu okuyan kişinin yani SİZ'in okuduğunuz tarihte değişiklikler olabilir.
         * Eğer ben tekrar bir düzeltme yapmadıysam. Bunları araştırmanızı tavsiye ederim. İsterseniz bana mail bile atabilrisiniz.
         * 
         * mailim : ozanberkay34@gmail.com'dur <-- eğer bu mail değişirse onu güncellediğime dair bildirimi yaparım
         * 
         * iyi kodlamalar :D
         */
    }
}
