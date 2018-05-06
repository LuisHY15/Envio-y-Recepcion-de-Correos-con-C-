using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias Agregadas
using System.Net.Mail;
using System.IO;

namespace WindowsFormsApp2
{
    class mail
    {
        public void SMTP(string from, string subject, string body, string cc,string route)
        {
                DirectoryInfo Directt = new DirectoryInfo(route);

                //ciclo para leer los archivos seleccionados
                foreach (var arch in Directt.GetFiles("*"))
                {
                    //string Path = Convert.ToString(Directt);
                    //string Path2 = Convert.ToString(Path + @"\" + arch);

                    MailMessage mail = new MailMessage();
                    //servidor de salida 
                    SmtpClient SmtpServer = new SmtpClient("laredo.globalpc.net");

                    mail.From = new MailAddress("sistemasst@tramitaciones.com");
                    //a quien va dirigido
                    mail.To.Add(from);
                    //Agregar a copia a alguien
                    mail.CC.Add(cc);
                    //Nombre del correo
                    mail.Subject = subject;
                    //cuerpo del correo
                    mail.Body = body;

                    System.Net.Mail.Attachment attachment;
                    //adjunto de los archivos seleccionados como attachment
                    attachment = new System.Net.Mail.Attachment(route + @"\" + arch);
                    mail.Attachments.Add(attachment);
                
                    //Puerto
                    SmtpServer.Port = 587;
                    //Correo,password del correo a enviar
                    SmtpServer.Credentials = new System.Net.NetworkCredential("sistemasst@tramitaciones.com","T3649");
                    //seguridad SSL
                    SmtpServer.EnableSsl = true;
                    //Envio de correo
                    SmtpServer.Send(mail);
                }

        }

        public void POP()
        {

        }
    }
}
