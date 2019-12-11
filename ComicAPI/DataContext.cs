using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ComicAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComicAPI {
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ComicGenre> ComicGenres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<LikePost> LikePosts { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<User> ().ToTable ("User");
            modelBuilder.Entity<Chapter> ().ToTable ("Chapter");
            modelBuilder.Entity<Comic> ().ToTable ("Comic");
            modelBuilder.Entity<Genre> ().ToTable ("Genre");
            modelBuilder.Entity<ComicGenre> ().ToTable ("ComicGenre");
            modelBuilder.Entity<ComicGenre> ().HasKey (c => new { c.ComicID, c.GenreID });
            modelBuilder.Entity<Comment> ().ToTable ("Comment");
            modelBuilder.Entity<Post> ().ToTable ("Post");
            modelBuilder.Entity<Like> ().ToTable ("Like");
            modelBuilder.Entity<Answer> ().ToTable ("Answer");
            modelBuilder.Entity<LikePost> ().ToTable ("LikePost");
            var users = new User[] {
                new User {
                ID = 1, Username = "ThuNguyen", Email = "user@gmail.com",
                Password = "12345", Role = 0, Image = "https://middle.pngfans.com/20190505/lx/avatar-user-png-avatar-computer-icons-clipart-c26add6546fc41bb.jpg"
                },
                new User {
                ID = 2, Username = "NhutThuy", Email = "user@gmail.com",
                Password = "12345", Role = 0, Image = "https://middle.pngfans.com/20190505/lx/avatar-user-png-avatar-computer-icons-clipart-c26add6546fc41bb.jpg"
                },
                new User {
                ID = 3, Username = "TuongVi", Email = "user@gmail.com",
                Password = "12345", Role = 0, Image = "https://middle.pngfans.com/20190505/lx/avatar-user-png-avatar-computer-icons-clipart-c26add6546fc41bb.jpg"
                },
                new User {
                ID = 4, Username = "Admin", Email = "admin@gmail.com",
                Password = "12345", Role = 1, Image = "https://cactusthemes.com/blog/wp-content/uploads/2018/01/tt_avatar_small.jpg"
                },
                new User {
                ID = 5, Username = "Collaborator", Email = "collaborator@gmail.com",
                Password = "12345", Role = 2, Image = "https://cactusthemes.com/blog/wp-content/uploads/2018/01/tt_avatar_small.jpg"
                }
            };
            modelBuilder.Entity<User> ().HasData (users);
            var genres = new Genre[] {
                new Genre { GenreID = 1, Genre_name = "Trinh Thám" },
                new Genre { GenreID = 2, Genre_name = "Ngôn Tình" },
                new Genre { GenreID = 3, Genre_name = "Viễn Tưởng" },
                new Genre { GenreID = 4, Genre_name = "Xuyên Không" },
                new Genre { GenreID = 5, Genre_name = "Dị Giới" },
                new Genre { GenreID = 6, Genre_name = "Lịch sử" },
                new Genre { GenreID = 7, Genre_name = "Cổ đại" },
                new Genre { GenreID = 8, Genre_name = "Sắc hiệp" },
                new Genre { GenreID = 9, Genre_name = "Võng du" }
            };
            modelBuilder.Entity<Genre> ().HasData (genres);
            var chapters = new Chapter[] {
                new Chapter {
                ChapterID = 1, ComicID = 1, Title = "Đỗ Mạnh Cầm", STT = 1,
                Content = "",
                },
                new Chapter {
                ChapterID = 2, ComicID = 1, Title = "Khổ luyện", STT = 2,
                Content = ""
                },
                new Chapter {
                ChapterID = 3, ComicID = 2, Title = "Bộ mặt thật của 3 bà chị", STT = 1,
                Content = "Nắng gắt đổ như lửa, thời tiết nóng rát bao trùm khắp thành Thanh Châu. Hành lang sáng choang rộng lớn, bị nhấn chìm trong tiếng ồn ào huyên náo. Bệnh viện tựa hồ bận rộn hơn mọi ngày, có vẻ bệnh nhân nhập viện hôm nay có thân phận “đáng gờm”.Vài người bác sĩ bận áo blouse trắng vội vàng sải bước xuyên qua hành lang dài,vẻ mặt u trầm nghiêm túc, chỉ có mấy cô y tá trẻ tranh thủ lúc rãnh rỗi xúm xít vào bàn tán. Lúc Ôn Vãn đang gấp gáp đi ngang qua, tình cờ nghe được một câu: Đáng thương quá, còn nhỏ như vậy đã mắc chứng bệnh đấy.Không có tâm tư nhiều chuyện, bước chân của Ôn Vãn không ngừng nghỉ, cô “kìm lòng không đậu”, lấy tay nhét vào túi áo.Ngón tay ngập ngừng chạm nhẹ vào màn hình, trên màn hình vẫn hiển thị tin nhắn vừa nhận được —— một tấm ảnh chụp cực kì rõ nét. Tấm lưng trắng như tuyết của người phụ nữ hòa cùng màu da lúa mạch của người đàn ông, tạo nên hình ảnh đối lập mà hài hòa tươi sáng. Hai phần mềm mại,no đủ kề sát khuôn ngực rắn chắc của người đàn ông đang say trong giấc ngủ, còn đôi môi phấn hồng như có như không chà xát qua chiếc cằm sắc lạnh, một đôi mắt xinh đẹp và tinh tế ánh lên tia khiêu khích, nhìn thẳng vào màn hình.Ôn Vãn xem một lúc lâu, tay nhấn nút xóa.Từ lâu, trong dự liệu của cô đã tính tới sự xuất hiện của tấm hình này. Có lẽ, thời gian chuẩn bị tâm lí quá dài, vô tình khiến những cảm xúc bi thương tựa như bong bóng dần dầnxì hơi, sau cùng chỉ còn dư lại lớp da tàn lụi.Nếu bây gờ hỏi cô có cảm xúc gì không? Cô sẽ trả lời, không gì cả, ngoài sự bất đắc dĩ.Người đàn ông trong tấm ảnh là chồng cô, mà giờ khắc này nhìn anh ta, trong lòng cô chẳng thể dậy nổi chút cảm giác thương tâm.Nhớ tới gương mặt vừa rồi, Ôn Vãn đã hiểu vì sao Cố Minh Sâm khẩn thiết muốn ly hôn. Tuy Cố Minh Sâm và cô luôn ở riêng suốt thời gian dài, nhưng đây không phải là nguyên do chính. Nghĩ vậy, cô đứng dựa vào tường, cân nhắc gửi cho đối phương tin nhắn: Buổi tối về nhà, chúng ta nói chuyện.Ngẫm nghĩ nếu không nói rõ, chắc đối phương sẽ phũ phàng ngó lơ, cô bèn xóa bỏ dòng tin mới bấm, thay thành dòng: Tôi đã chuẩn bị xong đơn thỏa thuận li hôn, anh về xem, coi có cần bổ sung thêm gì không.Tin nhắn vừa gởi đi, cô âm thầm thở phào, lòng bàn tay nắm điện thoại túa ra những giọt mồ hôi nhỏ, làm thân máy màu trắng hơi hơi nóng lên.Cách đó không xa, cô y tá đang hướng Ôn Vãn, ngoắc ngoắc mấy ngón tay. Có điều, Ôn Vãn vẫn chưa hồi hồn, mãi đến khi y tá chạy đến trước mặt cô, vừa nói vừa thở phì phò: Bác sĩ Ôn, chủ nhiệm tìm chị kìa. Bệnh nhân lần này là nhân vật quan trọng đấy, nghe nói có gia thế là——Cô y tá trẻ muốn nói lại thôi, lia mắt quan sát chung quanh, hạ thấp giọng nói: Chị tự đi xem đi.Ôn Vãn giật mình, nhanh nhảu nhét điện thoại vào túi, trong lúc hoảng hốt, cô cảm nhận được điện thoại rung lên, không kịp nhìn kĩ nội dung tin nhắn, cô thu cảm xúc, ưỡn thẳng sống lưng và nói: Đi thôi.Trong phòng chủ nhiệm tụ tập không ít người. Thời điểm Ôn Vãn đẩy cửa bước vào, liền ngửi được mùi thuốc lá gay mũi. Tính chất công việc tạo thành thói quen, bản thân Ôn Vãn có hơi xem nặng sự sạch sẽ, lúc này không khỏi chau mày: Chủ nhiệm? Mạnh Hành Lương nghe được thanh âm, theo bàn công tác hướng mắt nhìn sang, giữa hai hàng chân mày ẩn hiện ý cười:  Đến đây, ngồi xuống đi. Ôn Vãn khẽ liếc nhìn xung quanh, trong phòng có bốn người đàn ông, trong đó người đàn ông lớn tuổi nhất vận bộ Đường trang* kiểu cũ, mấy người còn lại đều vận âu phục màu đen. Vài người mang theo ánh mắt rét buốt nhìn về phía cô, tạo nên khí thế khiến lòng người hoảng loạn.Ôn Vãn lập tức đoán được có chuyện, xem ra bệnh nhân nhập viện hôm nay, quả đúng không đơn giản.Chủ nhiệm bảo cô ngồi xuống, hướng về người đàn ông trung niên giới thiệu :  Đây là ông Hạ, còn đây là bác sĩ tốt nhất khoa tâm thần của bệnh viện chúng tôi, bác sĩ Ôn Vãn. Người được gọi là ông Hạ mang trên người khí thế cương nghị cùng thâm trầm đặc trưng của người đàn ông từng trải. Nghe chủ nhiệm giới thiệu, ông ta chỉ khẽ gật đầu với Ôn Vãn, sau đó ánh mắt lại quay sang người Mạnh chủ nhiệm. Nếu Ôn Vãn không nhìn lầm, cái nhìn của ông ta đối với cô tựa hồ có ý bất mãn?Bầu không khí nghiêm túc khiến Ôn Vãn có tí căng thẳng, tiếp theo cô nghe được thanh âm của ông Hạ, lạnh nhạt cứng ngắc giống như khí chất trên người truyền tới:  Mạnh chủ nhiệm nói với tôi, bác sĩ Ôn là người có trách nhiệm và uy tín, vì vậy mới giao việc này cho cô, hi vọng bác sĩ Ôn sẽ sử dụng hết tài năng cùng trái tim của một lương y, để tôi thấy được bản lĩnh của cô. Không biết có phải Ôn Vãn đa nghi hay không, cô cảm thấy lời nói của người đàn ông này, hàm chứa ý cảnh cáo.Thời điểm cô nhìn lại ông ta, ông Hạ đang khoan thai bưng ly trà, từ từ thưởng thức, bình phẩm trà, ánh mắt tựa hồ không dừng trên người cô nửa giây. Theo bản năng, đối với người này, Ôn Vãn sinh ra sự bài xích lẫn chán ghét. Đây là điều dễ hiểu, chả ai cảm thấy thoải mái khi bản thân bị uy hiếp ngầm cả. Cô quay đầu, nói với Mạnh Hành Lương:  Chủ nhiệm yên tâm, nếu đây là nhiệm vụ công tác của tôi, tôi nhất định sẽ tận lực làm tốt. Tận lực không đủ, phải là toàn lực. Ông Hạ đặt ly trà xuống cái bàn phía trước, chống quải trượng, lạnh lùng liếc nhìn cô:  Đình Diễn là đứa cháu duy nhất kế thừa huyết mạch của tôi. Thằng bé năm nay mới 16, còn chưa đến tuổi trưởng thành. Nó phải chịu nhiều đả kích nên mới biến thành bộ dáng của ngày hôm nay. Ông Mạnh một mực coi trọng cô, ắt hẳn là có nguyên nhân—— Ông ta cố ý dừng một chút, càng đến cuối câu càng nhấn nhá ngữ điệu:  Bác sĩ Ôn, ngàn vạn lần đừng khiến tôi thất vọng. Gân xanh trên trán Ôn Vãn nhảy dựng, suy nghĩ phiêu diêu bay về bốn năm trước. Tâm tình khi đó và bây giờ, giống nhau như đúc , hoặc có thể do diện mạo hung dữ độc ác của họ quá giống nhau.Trong lòng Ôn Vãn vô cùng căm phẫn, nhưng từ đầu đến cuối không biểu hiện ra ngoài. Mãi đến khi cô ra khỏi phòng làm việc của chủ nhiệm, lúc này, mới khép chặt hai mắt.Đương niên cô từng nghe kể về Hạ gia, tại thành Thanh Châu, thế lực của họ rất lớn, không ai có can đảm trêu vào. Con trưởng của Hạ gia – Hạ Phong bất hạnh chết trẻ, bỏ lại vợ góa con côi. Vài năm trước, con dâu lại bỏ trốn cùng người đàn ông khác, đến giờ vẫn không có tin tức, chỉ còn cậu bé Hạ Đình Diễn sớm chiều cận kề ông nội. Hiện tại, cậu bé đáng thương mắc phải chứng bệnh đấy, khiến ông Hạ lo lắng, nóng nảy, sốt ruột.Xem ra cô phải đối mặt với vấn đề khá hóc búa. Ôn Vãn bụng bảo dạ, cô đến bệnh viện chưa được bao lâu. Mạnh chủ nhiệm không ngượng mồm, mặt dày tâng bốc cô lên trời, bảo là chuyên gia trong lĩnh vực này. Ngụ ý đã quá rõ, nếu có chuyện xảy ra, cô làm vật hi sinh là lựa chọn chính xác, hợp lí nhất.Ôn Vãn hiểu đạo lí “đối nhân xử thế” bạc bẽo của đời, vì thế, dù biết ý tứ của Mạnh chủ nhiệm, cô vẫn giữ bình tĩnh, không biểu hiện sự bất mãn hay phẫn nộ dư thừa. Nếu là vài năm trước, phỏng chừng cô đã giận đùng đùng, bắt ông ta nói cho ra lẽ. Hiện tại thì không, trừ khi cô không muốn làm công việc này nữa.Đi lên phía trước vài bước, mới chợt nhớ tới tin nhắn chưa kịp xem, Ôn Vãn vội vàng lấy ra nhìn, quả nhiên nội dung cực kỳ phù hợp với phong cách của Cố Minh Sâm, độc một chữ: ĐượcNgay cả dấu chấm câu cũng không có, xem ra người đàn ông đấy đối với cô, trước hay sau, chỉ có chán ghét.Vẻ mặt Ôn Vãn không thay đổi, nhét điện thoại vào túi, cầm bệnh án của chủ nhiệm đưa, trở về phòng làm việc. Phụ nữ có thể trắng tay trên vài phương diện, nhưng công việc và tôn nghiêm, tuyệt đối phải giữ kĩ trong tay, trước mắt nên ưu tiên chuyện của Hạ gia, còn những vấn đề khác, sẽ bàn tính sau."
                },
                new Chapter {
                ChapterID = 4, ComicID = 2, Title = "Xui Kiếp", STT = 2,
                Content = " Trước khi tan việc nhận được điện thoại của Tiêu Tiêu, vừa đúng lúc Ôn Vãn cần xả nỗi bực tức trong lòng, hai người bèn hẹn gặp nhau ở một quán ăn Nhật. Lúc Ôn Vãn tới, đã thấy Tiêu Tiêu ngồi ngay ngắn, mút mút thức ăn, tặng cô nụ cười tươi rói, miệng liên tục bắn ra những âm thanh giòn giã:   Giời ơi! Nhìn sắc mặt u ám của cậu kìa, khó trách Cố Minh Sâm ở bên ngoài nuôi dưỡng tình nhân nhỏ bé. Bình thường đi ra đường, cậu không soi gương à?   Mấy lời độc địa của cô bạn thân, Ôn Vãn nghe đã nghe nhàm tai, lười so đo cùng cô nàng. Chuyện liên quan đến Cố Minh Sâm, người bên ngoài đã biết rõ, không thiếu những kẻ thầm cười nhạo báng ở sau lưng Ôn Vãn, thậm chí có vài người còn là bằng hữu của cô. Cô ngồi yên lặng một lúc mới ấp úng nói:   Cậu biết rõ vấn đề giữa tớ và anh ta, đâu chỉ đơn giản như vậy.   Tiêu Tiêu và Ôn Vãn đã làm bạn mười mấy năm, chuyện tình dây dưa của Ỗn Vãn và Cố Minh Sâm, Tiêu Tiêu là người rõ nhất, đó chính là vết sẹo sâu nhất trong lòng Ôn Vãn. Tiêu Tiêu thở dài, hất mấy lọn tóc xoăn xõa bên vai ra sau lưng, cầm đũa gắp miếng cá hồi:   Khi đó, cậu không nên chấp nhận lấy anh ta. Giờ thì tốt rồi, vẫn là “hàng đóng gói” nguyên vẹn, chỉ là tự dưng gánh thêm cái danh ô uế: người phụ nữ bị chồng ruồng bỏ. Về sau muốn gả cho người khác cũng khó.   (À, nữ chính sạch, còn nam chính thì không) Ôn Vãn làm sao không hiểu ý của Tiêu Tiêu, hễ nhắc đến Cố Minh Sâm thì ngực cô liền nhói đau. Tuổi trẻ của mỗi người luôn tồn tại một cá nhân nào đấy, đóng vai trò thử thách và chứng mình sự khờ dại cùng khiếm khuyết của chúng ta. Cố Minh Sâm đã xuất hiện vào lúc Ôn Vãn chỉ vừa bước sang ngưỡng tuổi của một thiếu nữ ngây thơ, trong sáng.   Chuyện ly hôn, cậu tính thế nào?   Tất nhiên tâm tư của Ôn Vãn chưa kịp chuyển sang vấn đề này, sau một lúc lâu mới hồi hồn:   Cái gì?   Tiêu Tiêu liếc nhìn cô một cái, cho rằng cô muốn tiếp tục giả ngu:   Tớ cảnh cáo cậu, lần này tuyệt đối không được do dự nữa. Vì anh ta, cậu đã trả giánhiều rôi. Cái tên ấy có gì hay ho ngoài sự khốn nạn không giới hạn. Giờ cứ phí sức vào mấy em tiểu tam, tiểu tứ, tiểu ngũ….cho lắm vào. Sau này mắc bệnh gì thì cho chúng ôm nhau mà khóc .   Ôn Vãn cảm thấy buồn cười, Cố Minh Sâm không thích cô. Đối với anh ta, ly hôn giống như một sự giải thoát, cứu rỗi cho tâm hồn được tự do phiêu lãng. Thấy Ôn Vãn vẫn chưa tỏ rõ lập trường, Tiêu Tiêu nhíu nhíu hai đầu lông mày, đại khái còn đang thay cô, rủa xả cái gã đan ông kia vài trận, sau đó, trái suy phải xét, nghiêm túc nhắc nhở bạn:   Hiện tại tài sản trong nhà, đều đứng tên của hắn ta? Bà cụ vốn luôn đối xử tốt, thương yêu cậu, về sau nhớ khéo léo nhắc nhở, giành lấy những thứ thuộc về mình.   Ôn Vãn không muốn đề cập đến những việc này. Cô cùng Cố Minh Sâm ly hôn, kéo theo rất nhiều hệ lụy, việc quan hệ tới bà cụ, tạm thời chưa nói rõ được. Đầu bỗng dưng nhức nhối, cô nắn vuốt mi tâm, không nhịn được, lãng tránh sang chuyện khác:   Cậu biết gì về Hạ gia không? Nói cho tớ biết với   Tiêu Tiêu làm trong ngành truyền thông , hai năm trước, chuyển sang làm phóng viên, phụ trách chuyên mục về ngành giải trí. Mấy người độc mồm độc miệng thường hay gọi cô nàng và những đồng nghiệp là “bọn chó săn”. Đối với những ông tai to mặt lớn ở Thanh Châu, Tiêu Tiêu gần như hiểu biết khá đầy đủ. Nghe Ôn Vãn nói xong, động tác của Tiêu Tiêu khẽ khựng lại:   Vì sao đột nhiên nhắc đến Hạ gia?   Ôn Vãn nhàn nhạt liếc nhìn cô nàng, đắn đo nên mở miệng thế nào. Tiêu Tiêu thể hiện bản lãnh của một phóng viên: đầu óc nhạy bén, trực giác siêu chuẩn, hai con ngươi đen xoay vòng trong đôi mắt, ép sát Ôn Vãn, hỏi:   Có phải người của Hạ gia gặp chuyện không may, nhập viện vào khoa của cậu hả ?   Hào môn vốn sâu như biển, ẩn chứa bao điều đen tối cùng những lời gièm pha của người đời. Ôn Vãn mím môi không đáp, cười cười lắc đầu. Tiêu Tiêu không để ý, ánh mắt dấy lên đốm lửa sáng ngời như chộp được của quý, tay chống cắm, cười tít mắt:   Để tớ đoán thử xem, có phải là….Hạ Đình Diễn không? Ôn Vãn giật mình thon thót, như thể đang đối diện một bà đồng cái gì cũng biết, nhưng vẫn không quên dè chừng cô nàng:   Không được tăm tia thằng bé. Nó còn nhỏ, cậu đừng ác nhân ác đức đến mức lấy nó làm tư liệu sống.   Tiêu Tiêu bật tiếng cười giễu cợt, cảm hứng đang dâng trào bỗng dưng bị cắt ngang, ngã người về lại ghế dựa:   Tớ chẳng hứng thú với thằng bé đó đâu. Chuyện của Hạ Đình Diễn đã bị giới truyền thông đào bới đến tận gốc rễ, còn cái gì để viết nữa .   Ôn Vãn không bao giờ xem những tạp chí lá cải, nghe Tiêu Tiêu nói như vậy, đầu óc vẫn mờ mịt như cũ. Ôn Vãn không bao giờ xem những tạp chí lá cải, nghe Tiêu Tiêu nói như vậy, đầu óc vẫn mờ mịt như cũ. Tiêu Tiêu bực bội, nhìn cô bằng cặp mắt ghét bỏ:   Cho nên mới nói, mọi người đừng quá thiển cận mà xem thường công việc của chúng tớ. Những tin tức chúng tớ khai thác được, so với chương trình thời sự buổi tối còn chân thật, chính xác hơn.” Ôn Vãn cúi đầu, tiếp tục ăn, mặc cô bạn thao thao bất tuyệt, tô tô vẽ vẽ cho ngành nghề của bản thân, lát sau mới hỏi:   Vì sao làm như vậy? Hạ Đình Diễn còn rất nhỏ, mắc phải chứng bệnh đấy là bất hạnh của nó, ai thấy cũng mủi lòng tội nghiệp.   Tiêu Tiêu chống cằm, hai mắt dần đăm chiêu, đặt đũa xuống bàn:   Như vậy nè, thân thế của Hạ Đình Diên không hề đơn giản. Mọi người đều nói cậu ta là con trai của trưởng nam nhà họ Hạ - Hạ Phong, và mồ côi cha khi còn trong bụng mẹ. Nhưng theo chúng tớ điều tra được, sự thật không phải như vậy.   Ôn Vãn sửng sốt, Tiêu Tiêu hạ thấp giọng:   Cậu biết Hạ Trầm không? Là con trai thứ ba của Hạ gia, nghe nói Hạ Đình Diễn là con của anh ta.   Theo phản xạ, Ôn Vãn nhớ tới cặp mắt sâu đen trong bệnh viện, cô chau mày, chần chờhỏi:   Nhưng sự việc đó và căn bệnh của thằng bé, có liên quan gì nhau?   Tiêu Tiêu có chút khó xử, bởi vì những điều sâu xa hơn chưa từng được công bố ra ngoài ánh sáng:   Hạ Đình Diễn đã từng công khai nói rằng, con của Hạ Phong có liên quan đến Hạ Trầm, việc này gây nên sự ồn ào chấn động. Người đàn ông như Hạ Trầm, làm sao cho phép xuất hiện những nhân tố làm tổn hại đến lợi ích của anh ta. Cho dù là con ruột của mình, một khi đã cùng tiền tài đặt lên bàn cân, thì cũng là vật ngoài thân.” Ôn Vãn nhớ tới sự e dè của Hạ Đình Diễn khi nhìn thấy Hạ Trầm, và những lời cảnh cáo của anh ta với cậu bé. Trong đầu cô bất giác tưởng tượng ra những khả năng kinh hoàng—— chẳng lẽ Hạ Đình Diễn không hề mắc bệnh, cậu bé bị tống vào viện tâm thần, nguyên nhân là do biết rõ những bí mật liên quan đến Hạ Trầm? Giả sử cậu bé là con ruột của Hạ Trầm, thì thật sự cái tên Hạ Trầm này. . . . . . không bằng cầm thú. Sau khi ăn xong, Tiêu Tiêu rủ Ôn Vãn đi đến những quán ăn vặt. Ôn Vãn lấy cớ vẫn còn quá nhiều công việc chưa làm xong để từ chối. Tiêu Tiêu ngồi trong chiếc xe thể thao màu đỏ, vẻ mặt khinh thường:   Tớ bảo này, cậu sẽ sớm khôi phục cuộc sống độc thân. Trước khi cái tên kia đi thêm bước nữa, cậu nên nhanh chóng tìm cho mình một người đàn ông tốt để gả đi. Đây là vấn đền liên quan đến mặt mũi đấy nhé   Ôn Vãn chẳng hứng thú với loại việc này, cô không muốn dùng những cách hồ đồ để lấy lại mặt mũi:   Tớ chưa gặp được người đàn ông nào, khiến tớ an tâm giao phó đời mình cho họ.     Ít nhất hormone trong cơ thể cậu cũng bình thường như bao người khác.   Tiêu Tiêu nói chuyện luôn không biết điểm dừng, nghĩ gì thì cứ nói huỵt toẹt ra. Cô nàngnhìn Ôn Vãn bằng ánh mắt mập mờ, ám muội,   Cậu đã là bà già 28 tuổi, lại chưa bao giờ trải qua chuyện nam nữ, tớ không tin, ở độ tuổi này mà cậu không thèm muốn đàn ông.   Ôn Vãn nóng mặt, cố gắng duy trì trấn tĩnh:   Cuộc sống lẫn sinh hoạt hiện giờ của tớ rất tốt.   Tiêu Tiêu bày ra biểu tình “cậu đi lừa quỷ đi”, tay khởi động xe, đầu lại ló ra ngoài, dõi theo Ôn Vãn:   Tiểu Vãn.  Tiêu Tiêu hiếm khi gọi cô như vậy, mỗi lần dùng xưng hô này, chắc chắc cô nàng có điều đặc biệt cần nhấn mạnh. Ngọn đèn đường chiếu xuống khuôn mặt thanh tú của Ôn Vãn, lộ ra biểu tình hốt hoảng. Lần gần đây nhất, Tiêu Tiêu gọi cô như vậy, hình như là cái đêm trước khi cô quyết định kết hôn với Cố Minh Sâm . Thời gian trôi qua cực nhanh, hai năm chỉ giống như một cái chớp mắt. Thời gian trôi qua cực nhanh, hai năm chỉ giống như một cái chớp mắt.  Đã quyết định thì đừng bao giờ mềm lòng nữa. Cậu và Cố Minh Sâm, không chỉ là cách lòng mà còn——   Tiêu Tiêu thu vẻ mặt trơ trơ của mọi ngày, thở dài xa xăm,   Lời này hai năm trước, tớ đã từng nói, bây giờ tiếp tục nhắc lại. Giữa hai người chỉ đơn giản là đoạn nghiệt duyên, hãy sớm chặt đứt để giải thoát cho tất cả.  Những lời nói của Tiêu Tiêu, tựa như lưỡi dao sắc bén, rạch nát lớp màn che dấu những chuyện cũ tàn khốc và đau đớn của Ôn Vãn với Cố Minh Sâm. Ôn Vãn thường hay bụng bảo dạ, cô và Cố Minh Sâm là sự kết hợp tréo ngoe của hai cực trái dấu, là sản phẩm của vận mệnh trêu đùa….Đuôi xe của Tiêu Tiêu từ từ biến mất trong màn đêm. Làn gió đêm bất ngờ tập kích, Ôn Vãn rùng cả mình, hai tay vội nhét vào túi, vừa vặn chạm được chiếc điện thoại đang rung bần bật. Điện thoại của bà cụ gọi tới, không một lời dư thừa, trực tiếp bảo cô lập tức về nhà. Sau khi kết hôn, Ôn Vãn và Cố Minh Sâm luôn ở riêng, nhưng vào những ngày cuối tuần và những ngày nghỉ lễ, hai người vẫn mang theo tâm trạng “bằng mặt không bằng lòng”, cùng nhau xuất hiện trong nhà chính. Bà cụ vốn dễ bị đánh lừa, không hề phát hiện vấn đề của hai người. Hôm nay, giọng nói của bà trong điện thoại vô cùng uy nghiêm, khiến Ôn Vãn có chút hồi hộp, căng thẳng. Quản gia mở cửa cho cô, đè thấp giọng, lén nói cho cô biết:   Hôm nay, bà cụ nhận được một tin nhắn ——   "
                },
                new Chapter{
                    ChapterID = 5, ComicID = 2, Title = "", STT = 3,
                    Content = "Đã hơn một năm, Cố Minh Sâm cho Ôn Vãn “ăn quả lơ”, không hề nói chuyện cùng cô, hôn nhân của bọn họ luôn ngầm tồn tại sự giằng co, cưỡng chế lẫn nhau. Vì thế, hiện tại anh ta chủ động mở miệng, khiến Ôn Vãn ngơ ngác. Cô còn chưa kịp suy nghĩ cẩn thận về câu hỏi của anh ta, trước mặt đã bị một thứ đập vào. Cố Minh Sâm quẳng tờ tạp chí vào mặt cô. Người đàn ông đang trong cơn thịnh nộ, không kiểm soát được lực đạo của mình. Vì sự tấn công đột ngột của anh ta, sườn mặt của Ôn Vãn đau rát, bắt đầu ửng đỏ, nhưng khuôn mặt llại không chút cảm xúc. Cô bình tĩnh đặt ly thủy tinh trong tay xuống, khom người, cầm tờ tạp chí lên xem. Nội dung bài báo tương đồng với tin nhắn cô nhận được, có điều, tấm ảnh đã xóa mờ gương mặt của Cố Minh Sâm. Lúc này Ôn Vãn mới biết, người phụ nữ trong ảnh là ngôi sao đang rất nổi tiếng. Một lần nữa, Ôn Vãn buộc phải nhìn lại những hình ảnh gai mắt, hình chụp trên báo còn nét hơn trong tin nhắn. Anh cho là tôi làm? Ngại quá, tôi chẳng rỗi hơi đến thế đâu.   Ôn Vãn bị vu oan không hề nao núng, bình tĩnh biện luận cho mình. Cố Minh Sâm phì cười, ấn một tay lên kệ tủ phía sau:   Mẹ kiếp, định chơi trò bịp với tôi hả? Tay anh ta giật lại tờ tạp chí, giở đến trang “mấu chốt”, rồi dí sát mặt cô:   Không phải cô làm? Trừ cô ra, ai dám đối nghịch với tôi. Loại tin tức này, cho bọn nhà báo thêm một trăm lá gan, bọn chúng cũng không dám tùy tiện đăng. Ôn Vãn thản nhiên ngắm nhìn người đàn ông đang bộc phát lửa giận. Cô và Cố Minh Sâm quen biết 12 năm. Năm 16 tuổi, cô tới Cố gia, bắt đầu đoạn nghiệt duyên với Cố Minh Sâm – một người đàn ông lạnh lùng, luôn đặt bản thân trên mọi thứ. Cố Minh Sâm không thích cô, hình như từ lần gặp đầu tiên, anh ta đã ghét bỏ cô . Cố Minh Sâm chê bai cô, bảo cô là con bé quê mùa xuất thân từ nông thôn nghèo hèn, vừa cục mịch vừa không có giáo dục. Mười hai năm trôi qua, cô bé quê mùa năm nào đã hoàn toàn lột xác, nhưng trong mắt Cố Minh sâm, cô vẫn như buổi đầu gặp gỡ, chỉ là, lòng dạ đa đoan, quỷ kế hơn. Ôn Vãn học theo điệu cười khinh miệt của anh ta, ra vẻ “anh sao tôi vậy”, khí thế trên người không hề thấp kém hơn anh ta:   Não anh càng ngày càng teo nhở, thủ đoạn cấp thấp như vậy mà cũng nghĩ tới được. Lời này trực tiếp vạch trần sự ngu muội của anh ta, vừa nãy Cố Minh Sâm để lửa giận che mờ lí trí, giờ đã tỉnh táo nên có thể nhận định rõ hơn. Tuy nhiên, sự tự ái của đàn ông không cho phép anh ta cúi đầu, vẫn theo thói quen lạnh nhạt, bắt bẻ Ôn Vãn. Anh ta khom người, giọng đệu lạnh lẽo xuất ra hơi lạnh như băng:   Không ngờ Cố gia nuôi nhầm một con sói đội lốt cừu, đáng tiếc, đến giờ mẹ tôi vẫn chưa nhìn rõ bộ mặt thật của cô. Muốn ly hôn à? Tôi đồng ý với cô."+
                    "Anh ta nói rõ ràng dứt khoát, động tác lại cực kì thô bạo, dứt lời liền hung hăng đẩy cô ra. Lưng Ôn Vãn va mạnh vào mặt bàn lạnh lẽo, bả vai đụng phải vòi nước inox, đau điếng người. Cố Minh Sâm không thèm nhìn cô, lấy tay sửa sang lại vạt áo hơi nhăn nhúm:   Đừng quên những thứ cô đã cướp mất của tôi. Những gì cô nợ tôi, bây giờ nên tính toán cả vốn lẫn lời, hoàn trả cho chính chủ nhỉ? Anh ta nói đến phần sau, ngữ điệu bất chợt nhẹ nhàng trầm bổng:   Lúc trước là cô đồng ý kết hôn, hiện tại cũng là cô đòi ly hôn. Chuyện hôn nhân của Cố Minh Sâm tôi, trong mắt cô, chẳng đáng giá một xu. Tôi muốn đòi lại những gì mình nên có, sau này cô đừng trách tôi quá ác. Vóc dáng của Cố Minh Sâm cao lớn, thân hình cao 1,88 mét đứng ngược chiều ánh sáng, tạo thành bóng đen tăm tối, phủ kín Ôn Vãn. Ôn Vãn rùng mình, luồn khí lạnh lẽo lan tràn khắp đáy lòng:   Có ý gì? Ôn Vãn rùng mình, luồn khí lạnh lẽo lan tràn khắp đáy lòng:   Có ý gì? Cố Minh Sâm chậm rãi xoay người, khóe miệng nhếch thành ý cười bạc bẽo:   Cô thiếu tôi cái gì, chính cô biết rõ nhất. Sau khi ly hôn, cô đừng hòng mơ tưởng, bà cụ sẽ tiếp tục che chở cho cô. Ôn Vãn mím chặt môi, nụ cười của Cố Minh Sâm càng lúc càng ác liệt:   Kỳ thật ngẫm lại, chuyện ly hôn cũng thú vị lắm. Tôi rất muốn chứng kiến loại phụ nữ ham hư vinh, một lòng muốn bò lên cao như cô, sau này không còn Cố gia làm chỗ dựa, sẽ vẫy vùng, biến thành cái dạng gì. Cố Minh Sâm tàn nhẫn ném cho cô cái lườm sắc bén. Ánh mắt của anh ta quá phức tạp, Ôn Vãn không thể nhìn thấu, chỉ biết sự đụng chạm ở sau lưng, càng lúc càng đau đớn. Cô biết Cố Minh Sâm hận cô, nhưng không ngờ nỗi hận của anh ta đã biến đổi, vặn vẹo đến độ này. Thật ra cũng dễ hiểu, không ai có thể lưu tình với kẻ giết người cả! Buổi tối, Chu Nhĩ Lam nhất định không thả người, kiên quyết bắt hai người phải ở lại qua đêm. Ý tứ quá rõ rệt, thậm chí người làm đã chuẩn bị đủ chăn mềm cho đôi uyên ương trải qua một đêm xuân. Ôn Vãn đứng trước cái giường rộng lớn, sững sờ nhìn chiếc đệm đỏ thẫm. Cô như trở về hiện trường của đêm tân hôn hai năm trước, lúc đấy, Chu Nhĩ Lam cũng thay cô chuẩn bị mọi thứ chu đáo, bà luôn nhiệt tình đối xử tốt với cô. Đáng tiếc, có làm gì cũng không thể vực dậy những thứ đã héo rũ. Ôn Vãn khó xử nhìn Chu Nhĩ Lam:   Mẹ, con ——  Đừng nói gì cả, mẹ biết nỗi ấm ức mà con phải chịu.   Chu Nhĩ Lam nắm tay cô, nói lời thấm thía,   Lần này là Minh Sâm không đúng, mẹ đã dạy dỗ nó rồi. Đàn ông đều như thế,thỉnh thoảng ra ngoài gặp dịp thì chơi, nhưng họ vẫn biết đâu là nhà . Ôn Vãn ngắm nhìn mu bàn tay đang phủ trên tay mình, những đường gân xanh nổi đầy, các khe rãnh lỗi lõm chính là vết tích của năm tháng qua đi. Nói cho cùng, bà vẫn là một người mẹ, luôn ưu tiên dành sự yêu thương cho đứa con ruột của mình, cô không nên ký thác nhiều hi vọng vào bà. Không có người mẹ nào dễ dàng thừa nhận khuyết điểm của con trai trong đời sống hôn nhân, cũng không có bà mẹ chồng nào, thật tâm xem con dâu như chính con gái ruột do mình sinh ra. Nhất thời, Ôn Vãn không biết đối đáp ra sao, hơn nữa, phải nói như thế nào về chuyện ly hôn của hai người. Cô cảm thấy kì quái, vì sao Cố Minh Sâm vẫn chưa nói cho bà biết, chẳng lẽ anh ta định đùn đẩy trách nhiệm cho cô? Chu Nhĩ Lam thấy hai vợ chồng đều im lặng, cho rằng hai đứa con đã hiểu chuyện, vui vẻ hòa thuận với nhau. Trong lòng bà nhất thời vui như hoa nở, xoay người ra ngoài, trước khi đi còn nháy mắt với con trai:   Hai đứa nghỉ ngơi sớm đi   Ôn Vãn tức giận, trừng mắt với Cố Minh Sâm. Cố Minh Sâm lại phô ra bộ dạng: chả có việc gì liên quan đến ông, thoải mái cởi áo sơ mi, chuẩn bị đi tắm. Hai mắt Ôn Vãn trợn trắng, bật tiếng gọi:Mẹ. "
                },
                new Chapter{
                    ChapterID = 6, ComicID = 2, Title = "", STT = 4,
                    Content = ""
                },
                new Chapter{
                    ChapterID = 7, ComicID = 2, Title = "", STT = 5,
                    Content = ""
                },
                new Chapter{
                    ChapterID = 8, ComicID = 2, Title = "", STT = 6,
                    Content = ""
                },
                new Chapter{
                    ChapterID = 9, ComicID = 2, Title = "", STT = 7,
                    Content = ""
                },
            };
            var comics = new Comic[] {
                new Comic {
                ID = 1, Name = "Công Cuộc Bị 999 Em Gái Chinh Phục", Status = 0, Author = "Đỗ Cầm",
                Description = " Sẽ thế nào khi bạn mang trong người song tu thần kinh? Sở hữu khả năng xuyên qua 10 thế giới? Đào hoa vận không thua gì Rito (To love ru)? Lập 1 giàn harem, thủy tinh cung khủng nhất vũ trụ về khoe cho bọn bạn gato chơi.Đỗ Cầm có tất cả nhưng lại thừa 1 điều..... thừa bóng ma tâm lý về phụ nữ.Hãy đón xem công cuộc bị chinh phục của anh chàng đen đủi hay may mắn này nhé",
                Chapter_long = 0, Likes = 23, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//cong-cuoc-bi-em-gai-chinh-phuc.jpg",
                GenreID = 3
                },
                new Comic {
                ID = 2, Name = "Câu Chuyện Hồ Đồ", Status = 0, Author = "Phong Tử Tam Tam",
                Description = "Cố Minh Sâm giúp Ôn Vãn, lại không ngờ con bé kia lấy oán trả ơn.Mà Ôn Vãn không thẹn với lòng, dám khẳng định: Cô đối với Cố Minh Sâm, chỉ còn kém việc, dâng cái mạng nhỏ này cho anh ta. Kết quả chỉ đổi lấy tờ giấy thỏa thuận li hôn. Quả nhiên, thế giới này vô cùng bất công, người tốt lại chẳng được đền đáp.Dùng một câu để chốt văn án: Kết thúc đoạn hôn nhân hữu danh vô thực  đáng thất vọng, vận đào hoa của Ôn Vãn bỗng nhiên khởi sắc.",
                Chapter_long = 0, Likes = 44, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//cau-chuyen-ho-o.jpg",
                GenreID = 8
                },
                new Comic {
                ID = 3, Name = "Truyền Nhân Trừ Ma", Status = 1, Author = "Trì Đường",
                Description = " Sẽ thế nào khi bạn mang trong người song tu thần kinh? Sở hữu khả năng xuyên qua 10 thế giới? Đào hoa vận không thua gì Rito (To love ru)? Lập 1 giàn harem, thủy tinh cung khủng nhất vũ trụ về khoe cho bọn bạn gato chơi.Đỗ Cầm có tất cả nhưng lại thừa 1 điều..... thừa bóng ma tâm lý về phụ nữ.Hãy đón xem công cuộc bị chinh phục của anh chàng đen đủi hay may mắn này nhé",
                Chapter_long = 0, Likes = 11, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//truyen-nhan-tru-ma-ban-trai-toi-la-cuong-thi.jpg",
                GenreID = 2
                },
                new Comic {
                ID = 4, Name = "Yêu Sâu Nặng", Status = 0, Author = "Phong Tử Tam Tam",
                Description = "Cố Minh Sâm giúp Ôn Vãn, lại không ngờ con bé kia lấy oán trả ơn.Mà Ôn Vãn không thẹn với lòng, dám khẳng định: Cô đối với Cố Minh Sâm, chỉ còn kém việc, dâng cái mạng nhỏ này cho anh ta. Kết quả chỉ đổi lấy tờ giấy thỏa thuận li hôn. Quả nhiên, thế giới này vô cùng bất công, người tốt lại chẳng được đền đáp.Dùng một câu để chốt văn án: Kết thúc đoạn hôn nhân hữu danh vô thực  đáng thất vọng, vận đào hoa của Ôn Vãn bỗng nhiên khởi sắc.",
                Chapter_long = 0, Likes = 11, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//yeu-sau-nang-e-thieu-am-tham-cung-chieu-vo.jpg",
                GenreID = 4
                },
                new Comic {
                ID = 5, Name = "Thiên Đạo Đồ Thư Quán", Status = 0, Author = "Hoành Tảo Thiên Nhai",
                Description = " Sẽ thế nào khi bạn mang trong người song tu thần kinh? Sở hữu khả năng xuyên qua 10 thế giới? Đào hoa vận không thua gì Rito (To love ru)? Lập 1 giàn harem, thủy tinh cung khủng nhất vũ trụ về khoe cho bọn bạn gato chơi.Đỗ Cầm có tất cả nhưng lại thừa 1 điều..... thừa bóng ma tâm lý về phụ nữ.Hãy đón xem công cuộc bị chinh phục của anh chàng đen đủi hay may mắn này nhé",
                Chapter_long = 0, Likes = 30, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//thien-ao-o-thu-quan.jpg",
                GenreID = 1
                },
                new Comic {
                ID = 6, Name = "Tất Cả Bạn Gái Của Tôi Đều Là Lệ Quỷ", Status = 0, Author = "Thất Nguyệt Tửu Tiên",
                Description = "Cố Minh Sâm giúp Ôn Vãn, lại không ngờ con bé kia lấy oán trả ơn.Mà Ôn Vãn không thẹn với lòng, dám khẳng định: Cô đối với Cố Minh Sâm, chỉ còn kém việc, dâng cái mạng nhỏ này cho anh ta. Kết quả chỉ đổi lấy tờ giấy thỏa thuận li hôn. Quả nhiên, thế giới này vô cùng bất công, người tốt lại chẳng được đền đáp.Dùng một câu để chốt văn án: Kết thúc đoạn hôn nhân hữu danh vô thực  đáng thất vọng, vận đào hoa của Ôn Vãn bỗng nhiên khởi sắc.",
                Chapter_long = 0, Likes = 45, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//tat-ca-ban-gai-cua-toi-deu-la-le-quy.1572759769.jpg",
                GenreID = 5
                },
                new Comic {
                ID = 7, Name = "Bệnh Chiếm Hữu", Status = 0, Author = "Tùng Lan",
                Description = " Sẽ thế nào khi bạn mang trong người song tu thần kinh? Sở hữu khả năng xuyên qua 10 thế giới? Đào hoa vận không thua gì Rito (To love ru)? Lập 1 giàn harem, thủy tinh cung khủng nhất vũ trụ về khoe cho bọn bạn gato chơi.Đỗ Cầm có tất cả nhưng lại thừa 1 điều..... thừa bóng ma tâm lý về phụ nữ.Hãy đón xem công cuộc bị chinh phục của anh chàng đen đủi hay may mắn này nhé",
                Chapter_long = 0, Likes = 15, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//benh-chiem-huu.1573147505.jpg",
                GenreID = 1
                },
                new Comic {
                ID = 8, Name = "Cả Đời Chỉ Yêu Em", Status = 0, Author = "Mạc Vân Trà Sữa",
                Description = "Cố Minh Sâm giúp Ôn Vãn, lại không ngờ con bé kia lấy oán trả ơn.Mà Ôn Vãn không thẹn với lòng, dám khẳng định: Cô đối với Cố Minh Sâm, chỉ còn kém việc, dâng cái mạng nhỏ này cho anh ta. Kết quả chỉ đổi lấy tờ giấy thỏa thuận li hôn. Quả nhiên, thế giới này vô cùng bất công, người tốt lại chẳng được đền đáp.Dùng một câu để chốt văn án: Kết thúc đoạn hôn nhân hữu danh vô thực  đáng thất vọng, vận đào hoa của Ôn Vãn bỗng nhiên khởi sắc.",
                Chapter_long = 0, Likes = 45, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//ca-oi-chi-yeu-em.jpg",
                GenreID = 3
                },
                new Comic {
                ID = 9, Name = "Xin Hãy Ôm Em", Status = 0, Author = "Bắc Chi",
                Description = " Sẽ thế nào khi bạn mang trong người song tu thần kinh? Sở hữu khả năng xuyên qua 10 thế giới? Đào hoa vận không thua gì Rito (To love ru)? Lập 1 giàn harem, thủy tinh cung khủng nhất vũ trụ về khoe cho bọn bạn gato chơi.Đỗ Cầm có tất cả nhưng lại thừa 1 điều..... thừa bóng ma tâm lý về phụ nữ.Hãy đón xem công cuộc bị chinh phục của anh chàng đen đủi hay may mắn này nhé",
                Chapter_long = 0, Likes = 20, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//xin-hay-om-em.jpg",
                GenreID = 7
                },
                new Comic {
                ID = 10, Name = "Sư Huynh, Rất Vô Lương", Status = 0, Author = "Phong Tử Tam Tam",
                Description = "Cố Minh Sâm giúp Ôn Vãn, lại không ngờ con bé kia lấy oán trả ơn.Mà Ôn Vãn không thẹn với lòng, dám khẳng định: Cô đối với Cố Minh Sâm, chỉ còn kém việc, dâng cái mạng nhỏ này cho anh ta. Kết quả chỉ đổi lấy tờ giấy thỏa thuận li hôn. Quả nhiên, thế giới này vô cùng bất công, người tốt lại chẳng được đền đáp.Dùng một câu để chốt văn án: Kết thúc đoạn hôn nhân hữu danh vô thực  đáng thất vọng, vận đào hoa của Ôn Vãn bỗng nhiên khởi sắc.",
                Chapter_long = 0, Likes = 12, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//su-huynh-rat-vo-luong.jpg",
                GenreID = 8
                },
                new Comic {
                ID = 11, Name = "Điều Mặc Sư", Status = 0, Author = "Phong Tử Tam Tam",
                Description = "Cố Minh Sâm giúp Ôn Vãn, lại không ngờ con bé kia lấy oán trả ơn.Mà Ôn Vãn không thẹn với lòng, dám khẳng định: Cô đối với Cố Minh Sâm, chỉ còn kém việc, dâng cái mạng nhỏ này cho anh ta. Kết quả chỉ đổi lấy tờ giấy thỏa thuận li hôn. Quả nhiên, thế giới này vô cùng bất công, người tốt lại chẳng được đền đáp.Dùng một câu để chốt văn án: Kết thúc đoạn hôn nhân hữu danh vô thực  đáng thất vọng, vận đào hoa của Ôn Vãn bỗng nhiên khởi sắc.",
                Chapter_long = 0, Likes = 5, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//ieu-mac-su.jpg",
                GenreID = 5
                },
                new Comic {
                ID = 12, Name = "Hồ Ly Muốn Làm Người Mẫu", Status = 0, Author = "Diệp Sáp",
                Description = "Cố Minh Sâm giúp Ôn Vãn, lại không ngờ con bé kia lấy oán trả ơn.Mà Ôn Vãn không thẹn với lòng, dám khẳng định: Cô đối với Cố Minh Sâm, chỉ còn kém việc, dâng cái mạng nhỏ này cho anh ta. Kết quả chỉ đổi lấy tờ giấy thỏa thuận li hôn. Quả nhiên, thế giới này vô cùng bất công, người tốt lại chẳng được đền đáp.Dùng một câu để chốt văn án: Kết thúc đoạn hôn nhân hữu danh vô thực  đáng thất vọng, vận đào hoa của Ôn Vãn bỗng nhiên khởi sắc.",
                Chapter_long = 0, Likes = 4, Views = 100, Update_time = DateTime.Now,
                Image = "https://sstruyen.com/assets/img/story//ho-ly-muon-lam-nguoi-mau.jpg",
                GenreID = 6
                }
            };
            modelBuilder.Entity<Comic> ().HasData (comics);
            modelBuilder.Entity<Chapter> ().HasData (chapters);

            var comments = new Comment[] {
                new Comment {
                ID = 1, CommentTime = DateTime.Now,
                Content = "Truyện này hay lắm dịch giả cố lên nha",
                ComicID = comics.Single (s => s.Name == "Điều Mặc Sư").ID,
                UserID = users.Single (e => e.Username == "ThuNguyen").ID
                },
                new Comment {
                ID = 2, CommentTime = DateTime.Now,
                Content = "Giữ tiến độ nha",
                ComicID = comics.Single (s => s.Name == "Sư Huynh, Rất Vô Lương").ID,
                UserID = users.Single (e => e.Username == "NhutThuy").ID
                },
                new Comment {
                ID = 3, CommentTime = DateTime.Now,
                Content = "Không ai dịch tiếp hả ?",
                ComicID = comics.Single (s => s.Name == "Xin Hãy Ôm Em").ID,
                UserID = users.Single (e => e.Username == "TuongVi").ID
                },
                new Comment {
                ID = 4, CommentTime = DateTime.Now,
                Content = "Bạo chương nha các bạn",
                ComicID = comics.Single (s => s.Name == "Điều Mặc Sư").ID,
                UserID = users.Single (e => e.Username == "ThuNguyen").ID
                },
                new Comment {
                ID = 5, CommentTime = DateTime.Now,
                Content = "đọc đến chương 73-74 thấy tội anh Cố Yến Trinh mặc dù cùng họ với anh Cố Gia Minh nhưng die oan vãi chỉ định hù dọa anh Nghị ai ngờ họa sát thân",
                ComicID = comics.Single (s => s.Name == "Bệnh Chiếm Hữu").ID,
                UserID = users.Single (e => e.Username == "NhutThuy").ID
                },
                new Comment {
                ID = 6, CommentTime = DateTime.Now,
                Content = "dịch rồi mà k ai convert hết @@ truyện hay mà",
                ComicID = comics.Single (s => s.Name == "Điều Mặc Sư").ID,
                UserID = users.Single (e => e.Username == "TuongVi").ID
                },
                new Comment {
                ID = 7, CommentTime = DateTime.Now,
                Content = "truyện quá đẳng cấp :) nếu so với mấy thứ yy tự kỷ cứ như là Iphone với Bphone",
                ComicID = comics.Single (s => s.Name == "Thiên Đạo Đồ Thư Quán").ID,
                UserID = users.Single (e => e.Username == "TuongVi").ID
                }
            };
            modelBuilder.Entity<Comment> ().HasData (comments);

            var posts = new Post[] {
                new Post {
                ID = 1, UserID = 1, PostContent = "Mn tim giup minh cuon truyen",
                PostTime = DateTime.Now, Title = "Tìm truyện sắc hiệp"

                },
                new Post {
                ID = 2, UserID = 2, PostContent = "Tác phẩm các đh hay nhất từng đọc tên là gì. (Trong này có vài tác phẩm để đời ai cần ghé qua)",
                PostTime = DateTime.Now, Title = "Help me"

                },
                new Post {
                ID = 3, UserID = 3, PostContent = "Có trường hợp nào hộp thiên giới rỗng ko các đh. Ta nhận đc 1 hộp mà mở ra nó lag. Tải lại thì hộp ko còn mà vật phẩm cũng chẳng có",
                PostTime = DateTime.Now, Title = "Thắc mắc hộp thiên giới"

                },
                new Post {
                ID = 4, UserID = 4, PostContent = "Như trên nha nhiều vợ tí nó ms thú vị ko thì nhạt bỏ mẹ ra các đạo hữu ạ",
                PostTime = DateTime.Now, Title = "Xin truyện main bá đạo. Quyết đoán ( và main có nhìu vợ)"

                }
            };
            modelBuilder.Entity<Post> ().HasData (posts);
            var likes = new Like[] {
                new Like {
                ID = 1, UserID = 1, check = true, ComicID = 1
                },
                new Like {
                ID = 2, UserID = 3, check = true, ComicID = 1
                },
                new Like {
                ID = 3, UserID = 1, check = true, ComicID = 2
                },
                new Like {
                ID = 4, UserID = 3, check = true, ComicID = 4
                },
                new Like {
                ID = 5, UserID = 1, check = true, ComicID = 5
                },
                new Like {
                ID = 6, UserID = 3, check = true, ComicID = 6
                }
            };
            modelBuilder.Entity<Like> ().HasData (likes);
            var LikePosts = new LikePost[] {
                new LikePost {
                ID = 1, UserID = 1, check = true, PostID = 1
                },
                new LikePost {
                ID = 2, UserID = 3, check = true, PostID = 1
                },
                new LikePost {
                ID = 3, UserID = 1, check = true, PostID = 2
                },
                new LikePost {
                ID = 4, UserID = 3, check = true, PostID = 4
                },
                new LikePost {
                ID = 5, UserID = 1, check = true, PostID = 3
                },
                new LikePost {
                ID = 6, UserID = 3, check = true, PostID = 2
                }
            };
            modelBuilder.Entity<LikePost> ().HasData (LikePosts);
            var answers = new Answer[] {
                new Answer {
                ID = 1, AnswerTime = DateTime.Now, UserID = users.Single (x => x.Username == "ThuNguyen").ID,
                PostID = posts.Single (x => x.Title == "Tìm truyện sắc hiệp").ID,
                Content = "Ta đề cử Tối cường thần thoại đế hoàng , Thần khống thiên hạ"
                },
                new Answer {
                ID = 2, AnswerTime = DateTime.Now, UserID = users.Single (x => x.Username == "NhutThuy").ID,
                PostID = posts.Single (x => x.Title == "Tìm truyện sắc hiệp").ID,
                Content = "Linh vũ thiên hạ , hộ hoa cao thủ tại đô thị , 1 truyện huyền huyễn 1 truyện đô thị"
                },

                new Answer {
                ID = 3, AnswerTime = DateTime.Now, UserID = users.Single (x => x.Username == "TuongVi").ID,
                PostID = posts.Single (x => x.Title == "Help me").ID,
                Content = "Sao ta không lên cấp được nhỉ?"
                },
                new Answer {
                ID = 4, AnswerTime = DateTime.Now, UserID = users.Single (x => x.Username == "ThuNguyen").ID,
                PostID = posts.Single (x => x.Title == "Help me").ID,
                Content = "chờ các cao nhân vào chỉ điểm a. chở Dâm Lão huynh đệ lên tiếng a "
                }
            };
            modelBuilder.Entity<Answer> ().HasData (answers);
        }

    }
}