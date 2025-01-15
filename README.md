# okul-yonetim-sistemi-final
Bu proje, öğrenci, öğretim görevlisi ve ders yönetimi için tasarlanmış bir uygulamadır. Kullanıcıların konsol tabanlı bir arabirimle öğrenci ekleme, öğretim görevlisi ekleme, ders oluşturma ve öğrencileri derslere kaydetme gibi işlemleri gerçekleştirmesini sağlar. Veriler JSON formatında saklanır ve sonraki kullanımlar için korunur.

1.	Öğrenci Ekleme
Kullanıcı, sisteme yeni bir öğrenci ekleyebilir.
Öğrenci bilgileri (ad ve öğrenci numarası) kullanıcıdan alınır.
Bilgiler Ogrenciler.json dosyasına kaydedilir.

2.	Öğretim Görevlisi Ekleme
Yeni öğretim görevlileri sisteme eklenebilir.
Kullanıcıdan öğretim görevlisinin adı ve bölümü bilgileri alınır.
Bilgiler OgretimGorevlileri.json dosyasına kaydedilir.

3.	Ders Ekleme
Kullanıcı, yeni dersler oluşturabilir ve bu derslere bir öğretim görevlisi atayabilir.
Ders bilgileri (ders adı, kredi) kullanıcıdan alınır.
Kullanıcı, mevcut öğretim görevlileri listesinden bir öğretim görevlisi seçer.
Bilgiler Dersler.json dosyasına kaydedilir.

4.	Ders Kayıt
Kullanıcı, öğrencileri mevcut derslere kaydedebilir.
Sistem, mevcut öğrenci ve ders listesini gösterir.
Kullanıcı, öğrenci ve dersi seçerek kaydı tamamlar.
Kaydedilen bilgiler Dersler.json dosyasında güncellenir.

5.	Bilgileri Göster
Kullanıcı, sisteme eklenen bilgileri görüntüleyebilir:
Öğrenci bilgileri (Ogrenciler.json'dan okunur).
Öğretim görevlisi bilgileri (OgretimGorevlileri.json'dan okunur).
Ders bilgileri ve kayıtlı öğrenciler (Dersler.json'dan okunur).

6.	Otomatik Örnek Veri Ekleme
Program, JSON dosyalarında veri bulunmuyorsa, örnek verileri otomatik olarak ekler:
2 öğrenci, 2 öğretim görevlisi ve 2 ders önceden tanımlıdır.
Bu özellik, uygulamanın ilk kullanımını kolaylaştırmak için tasarlanmıştır.


Nasıl Çalışır?
JSON Dosyaları
Uygulama verileri şu JSON dosyalarında saklanır:
Dersler.json: Ders bilgileri (ders adı, kredi, öğretim görevlisi, kayıtlı öğrenciler).
Ogrenciler.json: Öğrencilerin isimleri ve numaraları.
OgretimGorevlileri.json: Öğretim görevlilerinin isimleri ve bölümleri.
Eğer dosyalar mevcut değilse, program bunları otomatik olarak oluşturur.

Konsol Menüsü
Uygulama, konsol üzerinden bir menü sağlar. Kullanıcı, aşağıdaki seçenekleri seçerek işlemlerini gerçekleştirir:
1.	Öğrenci Ekle: Yeni bir öğrenci eklemek için 1 girilir.
2.	Öğretim Görevlisi Ekle: Yeni bir öğretim görevlisi eklemek için 2 girilir.
3.	Ders Ekle: Yeni bir ders oluşturmak için 3 girilir.
4.	Ders Kayıt: Bir öğrenciyi derse kaydetmek için 4 girilir.
5.	Bilgileri Göster: Tüm öğrenci, öğretim görevlisi ve ders bilgilerini görüntülemek için 5 girilir.
6.	Çıkış: Programı sonlandırmak için 6 girilir.
Her seçenekte kullanıcıdan gerekli bilgiler istenir ve işlemler gerçekleştirilir.
