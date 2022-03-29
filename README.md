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




