using Azure.Core;
using IKProje.Domain.Entities.Entity;
using Microsoft.Extensions.FileProviders;

namespace IKProje.Presentation.Extensions
{
    public static class AddPicturePathToRequest
    {
     

       
        public static string AddPicturePath(this string picturePath,IFormFile picture,IFileProvider fileProvider)
        {
            //bir folder tanımladık wwwroot olan bunu file provider ile aldık.
            var wwwrootFolder = fileProvider.GetDirectoryContents("wwwroot");

            //Burada Dosyanın ismini belirliyoruz.bu şeklde bir random belirleyip üstüste binmelerinin önüne geçiyoruz dosyaların.
            var randomFileName = $" {Guid.NewGuid().ToString()}{Path.GetExtension(picture.FileName)}";//.jpg.png
                                                                                                              // aldığım isimle artık dosyamı buluşturmam gerekiyor.wwwrootFolderın userpicturesın fiziksel pathini alıyorum fiziksel adresini alıyorum
            var newPicturePath = Path.Combine(wwwrootFolder!.First(x => x.Name == "userpictures").PhysicalPath!, randomFileName);

            // artık yeni resmin pathi var ve kaydetme işine geçiyorum.

            using var stream = new FileStream(newPicturePath, FileMode.Create);
            //requestten gelen dosyayı artık streame kopyalıyorum.
             picture.CopyToAsync(stream);
            //dosyanın yolunu veritabanına yazdırıyoruz dosyanın ismiyle değil ama çünkü dosyanın ismini değiştirisek veritabanında da değiştirmek gerekebilir.
             picturePath = randomFileName;
            // son olarak dosyanın ismini artık picture ismini veriyoruz ve veri tabanında dosyanın ismini kaydediyoruz.

            return picturePath;
        }
    }
}
