# Fox Run

Phiên bản Unity: 2019

## 1. Adding Player

Mở thư mục Assets/2D Platformer/ Graphics/Player

Trong này ta sẽ thấy được 1 số sprite về nhân vật cáo.

### 1.1. Setup `player-idle`

![Setup player](md_assets/setup-player-idle.png)

- Pixels per units: 16
- Filter mode: point (no filter)
- Compression: none
- Sprite mode: multiple (bởi vì mình có 4 con cáo trong 1 sprite)

	- Chỉnh sửa Sprite của cáo để sử dụng trong Unity
	- Bấm vào Sprite Editor

	![Sprite editor](md_assets/spriteeditor.png)

	- Chọn `slice`
		- type: `grid by cell size`
		- pixel size: 32 x 32 (tự đo kích thước tương ứng với mỗi sprite)

	![Slice](md_assets/sliceby32.png)

	- Lúc tạo `sprite` này, tác giả để 1 ít phần dư, do đó trọng tâm của mỗi nhân vật sau khi cắt bị lệch quá nhiều => đặt padding để sửa

		- chọn `slice`
		- padding: `x:1`

	![Slice with padding](md_assets/slicewithpadding.png)

- Sau khi dùng `sprite editor` để cắt nhân vật xong, ta nhấn vào `sprite` tại khung project assets, chọn hình đầu tiên của con cáo rồi kéo vào `scene`, sau đó đối tên `player-idle-0` thành `Player`

![Done](md_assets/done.png)

### 1.2. Sorting Sprites with Layers

1 điều quan trọng là phải đảm bảo được player ở đúng layer.

Sử dụng `sorting layer system` có sẵn trong `unity` để đảm bảo 
vị trí của `player` với các `background layer` còn lại.

Chọn vào `Player object`, tại menu `layer`, chọn `add sorting layer`.

- `BG`: background
- `World`: quang cảnh thế giới
- `Player`: người chơi

Ta sẽ thêm vào các layer khác khi tiếp tục phát triển dự án

![Sorting Layer](md_assets/sortinglayer.png)

- Đặt layer của `back`, `middle` thành `BG`
- Đặt layer của `simple_setup_level` thành `World`
- Đặt layer của `Player` thành `Player`

Các `game object` được thêm vào sau sẽ mặc định layer `default`, đều
xếp trên `BG` và `Wolrd`

![Set layer](md_assets/setlayer.png)

### 1.3. Giving player physics

- Chọn `Player` game object
- `Add Component`
- Bọc 1 lớp `Rigidbody 2D`

![Rigidbody](md_assets/rigidbody.png)

`Rigidbody 2D` sẽ cung cấp 1 số yếu tố vật lý được cung cấp sẵn 
bởi hệ thống vật lý. Dùng cái này sẽ thuận tiện và dễ dàng hơn
so với việc tự tính toán các công thức vật lý.

Kéo con cáo đưa lên cao, sau đó nhấn vào `Play`, con cáo sẽ tự rơi xuống
do tác động của trọng lực

![Trong luc](md_assets/trongluc.png)

Con cáo rớt khỏi màn hình

Để con cáo có thể chạm vào mặt đất (tương tác với các game object khác), ta cần thêm vào 1 số tác động vật lý lên cơ thể thật (`solid body physics`)

- Chọn `Player` game object
- `Add Component`
- Chọn thư mục `Physics 2D`, chọn 1 trong các `collider` ở đây.
	
	- Thông thường, khi chúng ta tạo ra nhân vật, chúng ta thường 
	dùng `box collider` hoặc `capsule collider`. 
	- Trong trường hợp này, ta sẽ dùng `capsule collider` cho con cáo
	- Bởi vì dùng `box collider` thì nó hơi bự 1 tí so với con cáo

	![Capsule collider](md_assets/capsulecollider.png)

- Vòng tròn mặc định của `capsule collider` hơi to, ta cấu hình để bóp
sát `collider` vào nhân vật.

	- Chọn `component capsule collider` vừa tạo
	- Chọn `edit collider`
	- Kéo các góc sao cho vòng `collider` bao phủ phần thân của con cáo (không cần bao phủ hết)
	- Lúc này, khi thả xuống, nhân vật đã đứng trên mặt đất

	![Dung tren mat dat](md_assets/dungtrenmatdat.png) 

- Vấn đề nhân vật ngã lăn ra đất

	- Khi nhân vật rớt từ trên xuống, chạm vào góc của bức tường, nó ngã
	lăn ra đất
	- Trong game này, chúng ta không muốn yếu tố vật lý này diễn ra
	- Chọn phần `rigidbody`, kéo xuống phần `constraints`, tick vào `freeze rotation` (khóa xoay)

### 1.4. Moving Player around with some Scripts

Nhấn vào `assets`, tạo folder mới `scripts` để lưu trữ toàn bộ
`scripts`.

1 số quy ước đặt tên `script` thông dụng

- Bắt đầu với chữ in hoa
- Không có dấu gạch ngang ở giữa
- Không được đổi tên `script` sau khi đã gán cho `game object`

Ví dụ, ta tạo 1 script cho đối tượng `Player`, đặt tên là: `PlayerController`