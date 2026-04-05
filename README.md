Game Design Document: Endless Magnetic Escape
1. Tổng Quan (Game Overview)
1.1 Mô Tả Tóm Tắt
Endless Magnetic Escape là một game mobile/PC 2D dạng vertical-scrolling, nơi người chơi điều khiển một nhân vật cầm nam châm, liên tục phải bay lên cao bằng cách tương tác với các vật thể ngẫu nhiên xuất hiện trên màn hình. Trọng lực kéo nhân vật xuống dưới, trong khi một con alien đang đuổi theo từ phía dưới — người chơi phải sống sót càng lâu càng tốt.

1.2 Thông Tin Dự Án
Hạng mục	Chi tiết
Thể loại	Arcade / Endless Climber / Survival
Nền tảng	Mobile (Android/iOS), PC
Góc nhìn	2D Side-view / Vertical Scroll
Chế độ chơi	Single Player
Mục tiêu	Lên cao càng nhiều càng tốt, không bị alien bắt
2. Core Gameplay
2.1 Vòng Lặp Chính (Core Game Loop)
Mỗi lần chơi diễn ra như sau:

Nhân vật bắt đầu ở vị trí thấp, cầm nam châm.

Các vật thể ngẫu nhiên xuất hiện trên màn hình (kim loại, chướng ngại vật, item bonus...).

Người chơi chuyển đổi cực của nam châm (hút / đẩy) để tương tác với vật thể, tạo lực đẩy lên trên.

Trọng lực liên tục kéo nhân vật xuống.

Alien xuất hiện từ phía dưới và đuổi theo, tốc độ tăng dần theo thời gian.

Nếu bị alien bắt hoặc rơi xuống vùng alien, Game Over.

2.2 Cơ Chế Nam Châm (Magnet Mechanic)
Đây là cơ chế cốt lõi và độc đáo nhất của game:

Người chơi có thể chuyển đổi giữa cực Bắc (N) và cực Nam (S) của nam châm.

Cực giống nhau → Đẩy nhau (tạo lực phóng lên trên).

Cực khác nhau → Hút nhau (kéo nhân vật lên gần vật thể).

Mỗi vật thể trên màn hình có cực từ riêng hiển thị bằng ký hiệu N/S.

Người chơi phải nhanh chóng đọc cực của vật thể và quyết định dùng cực nào để di chuyển lên.

2.3 Trọng Lực (Gravity)
Trọng lực kéo nhân vật xuống liên tục với gia tốc cố định.

Nếu người chơi không tương tác với vật thể, nhân vật sẽ rơi xuống vùng của alien.

Cơ chế này tạo áp lực liên tục, buộc người chơi phải luôn hành động.

3. Nhân Vật (Player)
3.1 Mô Tả
Nhân vật là một người cầm nam châm lớn, đang cố gắng bay lên cao để thoát khỏi sự truy đuổi của alien. Nhân vật không có khả năng tự bay mà hoàn toàn phụ thuộc vào tương tác nam châm.

3.2 Điều Khiển
Chuyển cực N/S: Tap / Click chuột trái.

Mục tiêu vật thể: Tự động hoặc swipe để nhắm.

Di chuyển ngang: (Tùy chọn) Có thể thêm sau nếu cần.

3.3 Trạng Thái Nhân Vật
Alive: Đang di chuyển, tương tác với vật thể.

Falling: Không tương tác được vật thể nào, đang rơi.

Dead: Bị alien chạm vào hoặc rơi xuống vùng dưới màn hình.

4. Vật Thể Trên Màn Hình (Spawned Objects)
4.1 Kim Loại Cơ Bản (Magnetic Object)
Spawn ngẫu nhiên trên màn hình.

Có cực từ N hoặc S hiển thị rõ ràng.

Người chơi dùng nam châm để hút/đẩy nhằm di chuyển lên.

Sau khi tương tác xong, vật thể biến mất hoặc mất từ tính.

4.2 Item Ngẫu Nhiên (Random Collectible)
Xuất hiện xen kẽ các vật thể từ tính.

Thu thập khi nhân vật đi qua.

Hiệu ứng: Điểm thưởng, làm chậm alien tạm thời, tăng lực nam châm...

4.3 Chướng Ngại Vật (Obstacles)
(Dự kiến Phase 2) Vật thể không thể tương tác từ tính, va chạm làm nhân vật bị văng hoặc mất điểm.

5. Kẻ Thù (The Alien)
5.1 Mô Tả
Một con alien đang đuổi theo nhân vật từ phía dưới màn hình. Alien không thể bị tiêu diệt — người chơi chỉ có thể thoát bằng cách lên cao hơn.

5.2 Hành Vi
Bắt đầu ở phía dưới màn hình ngay khi game start.

Di chuyển liên tục lên phía nhân vật.

Tốc độ tăng dần theo thời gian (tạo cảm giác cấp bách).

Khi chạm vào nhân vật → Game Over.

5.3 Scaling Độ Khó
0–30 giây: Alien di chuyển chậm, nhiều thời gian để phản ứng.

30–60 giây: Alien tăng tốc, nhiều vật thể hơn xuất hiện.

60+ giây: Alien nhanh, nhiều vật thể từ tính cùng lúc, khó chọn cực đúng.

6. Độ Khó & Thử Thách (Challenge Design)
6.1 Yếu Tố Gây Khó
Nhiều vật thể từ tính xuất hiện cùng lúc → Phải chọn đúng vật thể và đúng cực.

Item ngẫu nhiên xuất hiện chen ngang → Gây phân tâm.

Alien ngày càng nhanh → Áp lực thời gian tăng cao.

6.2 Cân Bằng Gameplay
Giai đoạn đầu: Ít vật thể, cực hiển thị rõ, alien chậm.

Tăng dần số lượng vật thể và tốc độ alien theo điểm số hoặc thời gian.

Thêm gợi ý hình ảnh (flash highlight) để người chơi mới không bị ngợp.

7. Tiến Trình & Điểm Số (Progression & Scoring)
7.1 Hệ Thống Điểm
Điểm tăng theo độ cao đạt được.

Bonus điểm khi thu thập item.

Combo bonus: Tương tác nhiều vật thể liên tiếp không rơi.

7.2 High Score
Lưu điểm cao nhất của người chơi.

Hiển thị leaderboard (nếu có kết nối mạng).

8. UI/UX & Game Feel ("Juicy")
8.1 Visual Feedback
Hiệu ứng lực từ khi chuyển cực (spark, magnetic field animation).

Screen shake nhẹ khi tương tác mạnh.

Particle trail theo nhân vật khi bay lên.

Flash đỏ khi alien đến gần.

8.2 Âm Thanh (Sound Design)
Tương tác nam châm: Tiếng buzz điện từ, tiếng swoosh khi đẩy/hút.

Thu thập item: Tiếng ping/chime tươi vui.

Alien tiếp cận: Nhạc nền tăng tempo, tiếng growl của alien.

Game Over: Âm thanh thất bại kịch tính.

Nhạc nền: Nhạc arcade energetic, loop liên tục.

9. Kiếm Tiền (Monetization)
9.1 Mô Hình Đề Xuất
Free to Play + In-App Purchase.

Rewarded Ads: Xem quảng cáo để hồi sinh 1 lần duy nhất.

Remove Ads: Gói mua một lần để xóa quảng cáo.

Skins: Bán skin nhân vật / nam châm (không ảnh hưởng gameplay).

10. Lộ Trình Phát Triển (Development Roadmap)
Phase 1 — Core Gameplay (Deadline: 2 ngày)
Cơ chế di chuyển bằng nam châm (hút/đẩy).

Spawn vật thể ngẫu nhiên có cực từ.

Hệ thống trọng lực và Alien đuổi theo.

Xử lý Game Over và hiển thị điểm số cơ bản.

Phase 2 — Polish & Content
Thêm item ngẫu nhiên và chướng ngại vật.

Hệ thống âm thanh và hiệu ứng Visual (particles, screen shake).

UI/UX hoàn chỉnh và Leaderboard.

Phase 3 — Monetization & Launch
Tích hợp quảng cáo và Shop skin.

Testing & Bug fix.

Publish lên Store.
