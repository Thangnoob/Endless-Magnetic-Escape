# Endless Magnetic Escape 🧲

Một tựa game arcade sinh tồn tốc độ cao được phát triển bằng Unity. Tận dụng định luật từ tính để trốn thoát khỏi hiểm họa đang rượt đuổi từ bên dưới!

---

## 🛑 1. Tổng Quan (Game Overview)

### 1.1 Mô Tả Tóm Tắt
**Endless Magnetic Escape** là một game mobile/PC 2D dạng *vertical-scrolling* (cuộn dọc). Người chơi điều khiển một nhân vật cầm nam châm, liên tục phải bay lên cao bằng cách tương tác lực hút/đẩy với các vật thể ngẫu nhiên xuất hiện trên màn hình để trốn thoát khỏi một con Alien dữ tợn đang truy đuổi gắt gao phía dưới.

### 1.2 Thông Tin Dự Án
| Hạng mục | Chi tiết |
| :--- | :--- |
| **Thể loại** | Arcade / Endless Climber / Survival |
| **Nền tảng** | Mobile (Android), PC |
| **Góc nhìn** | 2D Side-view / Vertical Scroll |
| **Chế độ chơi** | Single Player (Chơi đơn) |
| **Mục tiêu** | Leo cao nhất có thể, không bị Alien bắt |

---

## 🕹️ 2. Core Gameplay

### 2.1 Vòng Lặp Chính (Core Game Loop)
Player điều hướng $\rightarrow$ Chuyển đổi Cực Nam châm (Hút/Đẩy) $\rightarrow$ Tận dụng Lực Từ Trường để nhân vật di chuyển lên cao $\rightarrow$ Alien rượt đuổi $\rightarrow$ Tăng điểm số (theo thời gian) $\rightarrow$ Alien truy đuổi nhanh hơn 

### 2.2 Cơ Chế Nam Châm (Magnet Mechanic)
Đây là "linh hồn" tạo nên sự độc đáo của trò chơi:
* 🔋 **Cực giống nhau** $\rightarrow$ **Đẩy nhau**: Tạo lực đẩy tác động lên nhân vật.
* 🧲 **Cực khác nhau** $\rightarrow$ **Hút nhau**: Kéo nhân vật áp sát vào vật thể.
* Người chơi phải liên tục quan sát ký hiệu **N** (Bắc) và **S** (Nam) trên vật thể để đưa ra quyết định chuyển cực kịp thời.

---

## 🏃 3. Nhân Vật & Điều Khiển

### 3.1 Trạng Thái Nhân Vật
* **Alive:** Đang di chuyển và tương tác tốt.
* **Falling:** Đang rơi tự do do không bám được vào vật thể nào.
* **Dead:** Bị Alien tóm gọn.

### 3.2 Hệ Thống Điều Khiển
* **Chuyển cực N/S:** Chạm màn hình (Mobile) / Click chuột trái hoặc Space (PC).
* **Nhắm mục tiêu:** Joystick điều hướng.

### 3.3. Physics Configuration (Technical Specs)

Để đảm bảo cảm giác điều khiển (**Game Feel**) đồng nhất và ổn định cho cơ chế hút/đẩy nam châm, các thông số vật lý của **Player** được thiết lập trong Unity Rigidbody 2D như sau:

| Parameter | Value | Design Purpose |
| :--- | :--- | :--- |
| **Body Type** | `Dynamic` | Cho phép Player phản hồi với lực từ trường và va chạm vật lý. |
| **Mass** | `1.0` | Khối lượng tiêu chuẩn để tính toán lực Magnetic ($F = m \cdot a$) đồng bộ. |
| **Linear Damping** | `1.0` | Giúp Player dừng lại mượt mà, tránh tình trạng trượt vô tận khi ngừng tương tác lực. |
| **Gravity Scale** | `1.0` | Giữ trọng lực mặc định để người chơi cảm nhận được độ nặng khi rơi tự do. |

## 🛸 4. Hệ Thống Vật Thể & Kẻ Thù

### 4.1 Vật Thể (Spawned Objects)
* **Vật thể từ tính:** Điểm tựa chính để leo lên.

Dự kiến:
* **Vật phẩm (Collectibles):** Điểm thưởng, làm chậm Alien hoặc gia tăng công suất nam châm.
* **Chướng ngại vật:** Các mảnh vỡ không có từ tính, va chạm sẽ làm lệch hướng bay.

### 4.2 Kẻ Thù (The Alien)
Alien đóng vai trò là "vùng chết" di động ép người chơi phải tiến lên:
* **0 – 30 giây:** Di chuyển chậm, tạo không gian làm quen cho người chơi.
* **30 – 60 giây:** Bắt đầu tăng tốc, tần suất vật thể xuất hiện dày hơn.
* **Trên 60 giây:** Đuổi cực gắt, đòi hỏi phản xạ đọc cực từ tính ở mức tuyệt đối.

---

## ✨ 5. UI/UX & Game Feel ("Juicy")

* **Hình ảnh:** Hiệu ứng tia điện bùng nổ khi chuyển cực, rung màn hình nhẹ (Screen shake) khi tương tác mạnh, vệt sáng (Particle trail) kéo sau lưng nhân vật.
* **Âm thanh:** Tiếng buzz rè rè của điện từ, tiếng gầm gừ tăng dần của Alien khi áp sát, nhạc nền dồn dập mang phong cách Arcade.

---

## 🗺️ 10. Lộ Trình Phát Triển (Development Roadmap)

### 🟩 Phase 1 — Core Gameplay (Hoàn thành trong 2 ngày)
- [X] Xây dựng cơ chế vật lý nam châm (Hút / Đẩy).
- [ ] Hệ thống tự động Spawn vật thể có cực từ ngẫu nhiên.
- [ ] Trọng lực & Logic AI Alien rượt đuổi.
- [ ] Tính điểm (Score) và xử lý Game Over cơ bản.

### 🟨 Phase 2 — Polish & Content
- [ ] Thêm item tương tác và chướng ngại vật cản trở.
- [ ] Đắp hiệu ứng Visual (Particles, Screen shake) & Sound Effects đầy đủ.
- [ ] Làm UI hoàn chỉnh & Tích hợp Leaderboard (Bảng xếp hạng).

### 🟥 Phase 3 — Monetization & Launch
- [ ] Gắn quảng cáo Rewarded Ads & Xây dựng Shop Skin.
- [ ] Tối ưu hóa hiệu năng & Fix bug.
- [ ] Đóng gói và phát hành lên các Store.
