# Fox Run

Phiên bản Unity: 2019

Đôi lúc, việc cải thiện game không nằm ở việc `code` mà nằm ở những cấu hình từng rất nhiều
`component` khác nhau.

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

Init script

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```

### 1.5. Moving the Player

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```

- `60FPS`: `Update` is called `60 times`
- `30FPS`: `Update` is called `30 times`

Chọn đối tượng `Player`, chọn `PlayerController` script vừa tạo rồi kéo
vào khung `component`.

- Tạo biến `public` trong class, `public float moveSpeed`,
lúc này, tại component script của đối tượng `Player` sẽ có 1
field để ta có thể chỉnh sửa thông số của biến này.

![Move speed](md_assets/movespeed.png)

Để di chuyển nhân vật, ta cần truy cập đến các hàm tại đối tượng `RigidBody2D`, đối tượng này ta đã thêm vào nhân vật để mang đến các
hiệu ứng vật lý.

- Đầu tiên, ta cần tạo 1 biến `RidigBody2D` để lưu trữ tham chiếu đến
đối tượng này. Để gán giá trị cho biến này, ta quay lại giao diện `unity`, cầm kéo
thả `component RigidBody2D` vào vị trí trống tương ứng tại phần script.

```csharp
    public Rigidbody2D theBD;
```

- Tiếp theo, ta tiến hành thêm vận tốc (`velocity`) cho nhân vật vào mỗi lần `frame update`

```csharp
    // Update is called once per frame
    void Update()
    {
        theBD.velocity = new Vector2(moveSpeed, theBD.velocity.y);
    }
```

Lúc này, sau mỗi `frame update`, nhân vật sẽ di chuyển theo trục `x` 1 khoảng cách
bằng với giá trị tại biến `moveSpeed`, còn giá trị trục `y` giữ nguyên.

- Để kiểm soát việc di chuyển của nhân vật, ta dùng `Input System` hỗ trợ sẵn từ `unity`.

```csharp
    theBD.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theBD.velocity.y);
```

- Nếu bấm mũi tên trái hoặc chữ `A`, `Input.GetAxis("Horizontal")` sẽ mang giá trị -1
- Nếu bấm mũi tên phải hoặc chữ `D`, `Input.GetAxis("Horizontal")` sẽ mang giá trị 1
- Nếu để nguyên thì mang giá trị 0

Để tìm hiểu thêm về các giá trị `Input` này, vào Menu `Edit` > `Project Settings` > `Input Manager`.

### 1.6. Jumping

- Lắng nghe sự kiện người dùng bấm vào nút `space` trong phương thức `update`.
- Tăng giá trị trục `y`, giữ nguyên giá trị trục `x`
- Nhân vật nhảy lên cao, sau đó dựa vào trọng lực để rơi xuống
- Thay đổi độ lớn của trọng lực tác dụng lên nhân vật tại `Rigidbody2D component`: `Gravity Scale`
- Tạo biến `public float jumpForce` để đặt độ cao khi nhân vật nhảy

- `gravity scale` tăng lên nghĩa là nhân vật nặng hơn, `jump force` cũng tăng theo
- `GetButtonDown` diễn ra khi người dùng vừa nhấn vào 1 nút
- `GetButton` diễn ra khi người dùng nhấn nút hoặc giữ nút
- `GetButtonUp` diễn ra khi người dùng thả nút vừa nhấn
- `Jump` là 1 giá trị trong `Input system`, vào `Input Manager` để xem chi tiết

```csharp
    void Update()
    {
        theBD.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theBD.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            theBD.velocity = new Vector2(theBD.velocity.x, jumpForce);
        }
    }
```

![Jump](md_assets/jummp.png)

### 1.7. Improving Gameplay Feel

- Khi nhảy lên rồi rớt xuống, 2 chân con cáo lún vào mặt đất, sau đó nó `reset` 2 chân lên mặt đất (cảm giác bị lag)

  - Lý do: hệ thống vật lý được chạy mỗi lần hàm `update` được gọi (xem code)
  - Trọng lực
  - Mỗi `frame update`, nhân vật rớt xuống 1 tí
  - Rớt 1 hồi thì nó nằm trong lòng đất
  - Sau đó hệ thống check `oops`, chân nhân vật này không được nằm dưới mặt đất, do đó hệ thống tự set lại, đặt nhân
 vật phía trên mặt đất
- Cách sửa: vào `component Rigidbody2d`, đặt thuộc tính `Collision detection` thành `continous`: lúc này
 mỗi lần `frame update`, hệ thống sẽ luôn check `collison` để đảm bảo rằng nhân vật không vô ý chui vào lòng đất

- Khi nhân vật đi đến chỗ cái tường (cần phải nhảy lên để vượt qua), nếu như tiếp tục
chọn mũi tên phải để đi tiếp thì khi nhảy, nhân vật sẽ bị dính vào bức tường.

  - cách giải quyết: thêm 1 đối tượng gọi là `physical material`
  - vào `assets` folder
  - chuột phải chọn `create`
  - `physics material 2D`, đặt tên là `Player Slippy`
  - Đặt thuộc tính `Friction` từ 0.4 thành 0
  
  - Mặc định nhân vật sẽ có 1 cái `physics material 2D` mang giá trị `Friction` là 0.4
  dẫn đến việc bị bug như đã mô tả. Ta ghi đè cái `physic` này để không còn bug nữa.
  - Tại `component capsule collider`, kéo cái `physic` mới này vào để thay thế cái mặc định.

![Improving](md_assets/improving.png)

Đôi lúc, việc cải thiện game không nằm ở việc `code` mà nằm ở những cấu hình từng rất nhiều
`component` khác nhau.

### 1.8. Stop Unlimited Jumping

Tạo 1 biến `boolean` lưu trữ trạng thái, nếu nhân vật đang đứng tại mặt đất thì cho
phép nhảy. Nếu nhân vật đang đứng trên không trung thì không cho phép nhảy.

Cần phải xác định được trạng thái liệu nhân vật có đang đứng trên mặt đất hay không?

Ý tưởng:

- Tạo 1 điểm ở chân của nhân vật
- Từ điêm này vẽ ra 1 vòng tròn nhỏ
- Trong phạm vi của vòng tròn này, nếu gặp đối tượng mặt đất thì => nhân vật đang đứng trên mặt đất

Làm sao để xác định đâu là mặt đất ???

Dựa vào `layer` (`unity layer system`).

#### 1.8.1. Unity Layer System

- Chọn đối tượng `simple_setup_level`, tại selectbox `layer`, bấm vào add new để
thêm mới 1 số layer, trước mắt sẽ thêm 2 layer:

  - `Ground`: những `game object` thuộc `layer` này sẽ tương ứng với phần đất
  - `Player`: những `game object` thuộc `layer` này sẽ tương ứng với người dùng

- Sau khi tạo xong `layer`, chọn `layer` cho `simple_setup_layer` là `Ground`
- Chọn `layer` cho `Player` là `Player`.

![Layer system](md_assets/layersystem.png)

#### 1.8.2. Xác định trạng thái nhân vật đang đứng trên mặt đất

Tạo biến `bool` lưu trạng thái liệu người dùng có đang đứng trên mặt đất hay không

```csharp
  private bool isGrounded;
```

Chỉ cho phép nhảy lên khi trạng thái `isGrounded` = `true`, tức là người dùng đang đứng
trên mặt đất

```csharp
  void Update()
  {
      theBD.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theBD.velocity.y);

      if (Input.GetButtonDown("Jump"))
      {
        if (isGrounded)
        {
          theBD.velocity = new Vector2(theBD.velocity.x, jumpForce);
        }
      }
  }
```

Xác định xem người dùng có đang đứng trên mặt đất hay không?

- Tạo 1 điểm ở dưới chân của người dùng (`add game object to Player`)
- Vẽ 1 vòng tròn nhỏ có bán kính `0.2f`
- Nếu trong bán kính của vòng tròn này có sự xuất hiện của 1 vật thể thuộc layer `Ground`
tức là người dùng đang đứng trên mặt đất

![Ground point](md_assets/groundpoint.png)

Gán `Ground Point` object vào `script` để xử lý va chạm, có 2 cách:

- 1. gán như là 1 `game object`
- 2. bởi vì mình chỉ muốn biến vị trí hiện tại của đối tượng để xác định va chạm, do đó chỉ cần truyền đối tượng `Transform`

Dùng cách 2, tạo 1 biến để lưu trữ đối tượng `Transform`, đối tượng này chứa vị trí của điểm dưới chân nhân vật `Ground Point`

```csharp
  public Transform groundCheckPoint;
```

Tạo 1 biến tiếp theo để lưu trữ `layer`, biến này chỉ ra rằng hiện tại `layer` mặt đất là layer nào

```csharp
  public LayerMask whatIsGround;
```

Tại mỗi lần `update`, ta kiểm tra xem vòng tròn dưới chân nhân vật có tiếp xúc với bất kì đối tượng
nào thuộc layer `Ground` hay không

```csharp
  void Update()
  {
      theBD.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theBD.velocity.y);

      isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

      if (Input.GetButtonDown("Jump"))
      {
          if (isGrounded)
          {
              theBD.velocity = new Vector2(theBD.velocity.x, jumpForce);
          }
      }
  }
```

Result

![Result](md_assets/stopunlimitedjumping.png)

### 1.9. Adding double jump

```csharp
void Update()
{
    theBD.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theBD.velocity.y);

    isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

    if (isGrounded) canDoubleJump = true;

    if (Input.GetButtonDown("Jump"))
    {
        if (isGrounded)
        {
            theBD.velocity = new Vector2(theBD.velocity.x, jumpForce);
        }
        else
        {
            if (canDoubleJump)
            {
                theBD.velocity = new Vector2(theBD.velocity.x, jumpForce);
                canDoubleJump = false;
            }
        }
    }
}
```

### 1.10. Animating the Player

- Tạo thư mục `assets/Animations/Player` để lưu trữ các hiệu ứng hoạt họa liên quan
đến `Player`
- Tại khung `game object`, chọn đối tượng `Player`
- Vào menu `Window`, chọn `Animation` > `Animation` rồi kéo cửa sổ này nằm cạnh
cửa sổ `Game` để thuận tiện
- Đảm bảo chọn vào đối tượng `Player` trên khung `game object`, sau đó nhấn `Create` để thêm
mới và lưu tập tin vào đúng thư mục trong `assets/Animations`, đặt tên `Player_Idle`
- Vào thư mục `assets/2D Platformer Assets/Graphics/Player` rồi tìm đến `Player Idle Sprite` đã cắt lúc trước,
kéo từng hình vào từng mốc thời gian theo thứ tự `1, 2, 3, 4`
- Để hiệu ứng chuyển động mượt thì nhớ lặp lại tấm hình số 1, lúc này thứ tự sẽ là: `1, 2, 3, 4, 1`

![Animation](md_assets/animatingplayer.png)

### 1.11. Switching Animations

Hiện tại trong game đang có 3 hiệu ứng hoạt họa dành cho `Player`

- `Player_Idle`: hoạt họa khi `Player` đứng yên trên mặt đất
- `Player_Run`: hoạt họa khi `Player` di chuyển sang trái hoặc phải (`moveSpeed` > 0)
- `Player_Jump`: hoạt họa khi `Player` nhảy lên không trung (`isGrounded` = false)

Chúng ta cần xác định và cấu hình việc chuyển cảnh các hoạt họa

- Vào menu `Windows` > `Animation` > `Animator`
  
  ![Switching animation](md_assets/animationswitch1.png)

- Chuột phải lên `animation` `Player_Idle`, chọn `Make transition`, sau đó kéo tới đối tượng `Player_Run`
để cấu hình hiệu ứng chuyển cảnh giữa 2 `animation` này

  - Chọn lên mũi tên vừa được tạo ra để tiến hành cấu hình
  - Chúng ta muốn hiệu ứng chuyển cảnh diễn ra ngay lập tức, do đó, đặt giá trị tại `transition duration` về `0`
  - Mặc định, `exit time` xác định thời gian 1 `animation` kết thúc và tự động chuyển sang `animation` khác. Tuy nhiên, trong
  trường hợp này, ta muốn chuyển cảnh `animation` trong 1 số điều kiện nhất định, do đó tiến hành bỏ tick tại ô `has exit time`.
  Tại thời điểm này `animation` `Player_Idle` sẽ diễn ra mãi mãi, vì vậy ta cần xác định điều kiện để chuyển cảnh sang `animation` `Player_Run`.
  - Khi người dùng di chuyển qua trái hoặc phải (`moveSpeed` > 0), lúc này người dùng đang chạy nên ta chuyển cảnh từ `Player_Idle` sang
  `Player_Run`. Chọn tab `Parameters`, tiến hành khai báo 1 biến lưu giá trị `moveSpeed`, đặt cùng tên `moveSpeed`.
  - Quay lại chọn vào mũi tên, kéo xuống dưới, tại mục `List conditions`, tiến hành thêm 1 điều kiện để kiểm tra `moveSpeed`.
  - Theo chiều từ `Player_Idle` sang `Player_Run`, `moveSpeed` sẽ có giá trị lớn hơn `0.1`
  - Theo chiều từ `Player_Run` sang `Player_Idle`, `moveSpeed` sẽ có giá trị nhỏ hơn `0.1`

- Tương tự, khi chuyển từ `Player_Idle` sang `Player_Jump`, ta đặt điều kiện tham số `isGrounded` = `false`
- Khi chuyển từ `Player_Jump` sang `Player_Idle`, ta đặt điều kiện tham số `isGrounded` = `true`

- Khi nhân vật đang chạy, có thể chuyển sang trạng thái nhảy, do đó ta chuyển từ `Player_Run` sang `Player_Jump`
với điều kiện `isGrounded` = `false`

![Animator](md_assets/animator.png)

### 1.12. Controlling the Animator through code

Tạo 1 tham chiếu đến đối tượng `Animator` để kiểm soát đối tượng này thông qua `code`.

Thay vì tạo 1 tham chiếu `public` rồi kéo đối tượng tương ứng vào. Ta có thể khai báo
1 tham chiếu `private`, sau đó, trong hàm `start`, ta tiến hành gọi hàm tương ứng để lấy
được đối tượng tương ứng đang được gắn vào `game object` hiện hành.

```csharp
  void Start()
  {
      animator = GetComponent<Animator>();
  }
```

Sau này, khi có nhiều `game object` `Player`, ta không cần phải đi gán thủ công `animator` cho
từng cái nữa.

Chuyển sang giao diện `debug` để xem rõ hơn.

Tại phần dưới cùng của hàm `update`, ta tiến hành viết code để kiểm soát đối tượng `animator` này.

Tại đây, ta dùng hàm `Set` trên đối tượng `animator` để đặt giá trị tương ứng cho các tham số
đã được khai báo trong cửa sổ `Animator` trước đó, bao gồm:

- `moveSpeed`: dùng làm điều kiện xác định việc chuyển cảnh từ `Player_Idle` sang `Player_Run`
- `isGrounded`: dùng làm điều kiện xác định việc chuyển cảnh từ `Player_Idle` sang `Player_Jump` và `Player_Run` sang `Player_Jump`

```csharp
void update()
{
    theBD.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theBD.velocity.y);

    isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

    // ...

    animator.SetFloat("moveSpeed", Mathf.Abs(theBD.velocity.x));
    animator.SetBool("isGrounded", isGrounded);
}
```

### 1.13. Changing direction

Hiện tại hiệu ứng đã có, tuy nhiên khi đi lùi, nhân vật không xoay mặt về phía sau.

Trên `component` `Sprite Renderrer` có 1 thuộc tính là `Flip`, ta có thể lật 1 `sprite` hình
thông qua 2 trục `X` và `Y`. Trong đó, việc lật trục `X` đáp ứng được yêu cầu xoay mặt nhân
vật sang trái và phải. Do đó, giờ ta sẽ tìm cách để tham chiếu đến `component` này trong `script`.

Làm tương tự như `animator`, khai báo 1 biến `private` giữ tham chiếu, sau đó gọi hàm trong `start`
để hệ thống tự động tìm và gán đối tượng `Sprite Renderrer` đang gắn với `Player game object` hiện tại

```csharp
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        theBD.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theBD.velocity.y);

        // ...

        if (theBD.velocity.x < 0) theSR.flipX = true;
        else if (theBD.velocity.x > 0) theSR.flipX = false;

        // ...
    }
}
```

## 2. Camera

### 2.1. Attach Camera to follow the Player

Cách đơn giản nhất là kéo đối tượng `camera game object` vào đối tượng `Player game object` (để camera
là đối tượng con thuộc player). Camera sẽ di chuyển theo nhân vật, thậm chí cả khi nhảy.

Trong trò chơi này, ta không muốn điều đó diễn ra, vì vậy ta sẽ tạo `script` để điều khiển
`camera` theo ý.

- Vào folder `scripts`, tạo 1 script mới, đặt tên `CameraController`
- Kéo `script` vừa tạo này vào `camera game object`

Trong `script` này, ta cần phải tham chiếu đến 1 vật và `camera` sẽ di chuyển theo vật này.
Trong trường hợp game này, ta cần tham chiếu đến đối tượng `Player` từ `CameraController script`.

Tuy nhiên, để tái sử dụng `CameraController` này cho nhiều `game object` khác nhau, ta không nên gán
cứng kiểu dữ liệu `Player game object` vào đây.
Thay vào đó, chỉ cần giữ tham chiếu đến đối tượng `Transform` thuộc về `game object` là được.
(`camera` sẽ di chuyển dựa vào vị trí này)

Để di chuyển `camera`, ta cần chỉnh sửa vị trí `x, y, x` thuộc về thuộc tính `Transform` của
đối tượng `camera`.
Để tham chiếu đến đối tượng `Transform` của `camera`, ta chỉ cần gõ `transform` là xong. Bởi vì
hệ thống `unity` đã tự `inject` đối tượng `transform` này vào `script`.

Thay đổi vị trí hiện tại của `camera` thông qua việc đặt lại giá trị cho `transform.position`

- `x`: di chuyển theo chiều ngang của `target` (trong trường hợp này sẽ là `x` của `Player`)
- `y`: trong trường hợp này, ta không thay đổi `y`
- `z`: chiều sâu của camera, trong trường hợp này ta cũng không đổi

Sau đó quay lại giao diện `unity`, kéo đối tượng `Player game object` vào khung `Target` tại
`camera` là được. Thuộc tính `transform` trên `Player` sẽ tự động được truyền vào.

```csharp
public class CameraController : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
```

![CAmera](md_assets/camera.png)

### 2.2. Adding parallax for depth

Để tạo 1 số hiệu ứng hình ảnh cho game, ta sẽ áp dụng kĩ thuật `parallax`. Di chuyển
`camera` chứa cảnh của `Player` đồng thời di chuyển `camera` chứa cảnh `Background`.

Để thử nghiệm cơ bản, ta chỉ cần kéo `game object` tên `back` trở thành con của đối tượng `camera`.

Lúc này khi nhân vật di chuyển, `camera` di chuyển theo nhân vật, `backgroud` cũng di chuyển
theo `camera`, tạo hiệu ứng thế giới đang chuyển động.

Các bước tạo hiệu ứng sinh động cho game

- Ta đã có 2 nền sẵn:
  
  - 1 nền ở xa, hình bãi biển màu xanh (`back object`)
  - 1 nền ở trung gian, hình những ngọn cây (`middle object`)

- Khi nhân vật di chuyển, ta cần di chuyển đồng thời 2 nền này. Lúc này sẽ có cả 3 thứ cùng nhau di chuyển trên màn hình, bao gồm:
camera, hình ở xa và hình ở trung gian. Trong đó, camera và hình ở xa sẽ di chuyển cùng tọa độ `x`, hình trung gian sẽ di chuyển
bằng `0.5x`. Lúc này hiệu ứng tạo ra sẽ rất tuyệt vời.

- Đầu tiên, cần phải thay đổi vị trí của 2 nền trong `CameraController script`, do đó ta sẽ lưu giữ tham chiếu đến 2 đối tượng
`Transform` tương ứng (làm như đối tượng `Player` ở trên)

- Tại mỗi khung hình `update`, ta cần tính được khoảng cách mà nhân vật đã di chuyển theo trục `x` so với `frame` trước đó
- Dựa vào khoảng cách nhân vật đã di chuyển so với `frame` trước đó, ta tính được vị trí mới của 2 hình nền

```csharp
public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform farBackground, middleBackground;

    private float lastXPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastXPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

        float amountToMoveX = transform.position.x - lastXPosition;

        farBackground.position += new Vector3(amountToMoveX, 0f, 0f);
        middleBackground.position += new Vector3(amountToMoveX * .5f, 0f, 0f);

        lastXPosition = transform.position.x;
    }
}
```

![Parallax](md_assets/parallax.png)

### 2.3. Clamping camera vertically

Hiện giờ, khi nhân vật di chuyển, camera cũng di chuyển theo nhưng chỉ theo trục `x`, trục
`y` và `z` giữ nguyên. Tuy nhiên, nếu làm như này thì khi nhân vật nhảy lên sẽ không có cảm giác
chân thực. Tuy nhiên, ta cũng không muốn camera đi theo trục `y` của nhân vật bởi vì lúc này camera
có thể lên quá cao hoặc quá thấp, dẫn tới lệch khỏi khung hình.

Do đó, ta cần 1 biện pháp để di chuyển trục `y` của `camera` 1 cách hợp lý.

Để làm được điều này, ta đặt 2 giá trị `minHeight, maxHeight`, quay lại `editor`, tiến hành đo đạc và
đặt giá trị cho 2 biến này. Trong đó:

- `minHeight` là giá trị `y` thấp nhất, nếu thấp hơn giá trị này sẽ không tính
- `maxHeight` là giá trị `y` cao nhất, nếu cao hơn giá trị này sẽ không tính

Lúc này, ta sẽ tính toán như sau:

- Nếu `y` của nhân vật nằm trong khoảng `minHeight` đến `maxHeight` thì dùng `c = y`
- Nếu `y` của nhân vật lớn hơn `maxHeight` thì `c = maxHeight`
- Nếu `y` của nhân vật nhỏ hơn `minHeight` thì `c = minHeight` (trường hợp này diễn ra khi nhân vật bị rớt xuống hố)

Sau đó, ta đặt `position.y` của `camera` bằng giá trị `c`.

```csharp
 transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
```

![Clamping camera vertically](md_assets/clampingcameravertically.png)

### 2.3. Adding parallax for vertical direction

Hiện giờ việc chạy 3 cảnh song song với nhau theo trục `x` đã tạo hiệu ứng game rất đẹp.
Tuy nhiên, khi nhân vật nhảy lên, 3 cảnh không di chuyển `y` theo.

Do đó, để hoàn hảo hơn, ta đồng thời di chuyển cùng lúc nhiều cảnh ở cả 2 chiều `x` và `y`.

Trước đó, ta khai báo biến `lastXPosition` để lưu lại giá trị `X` ở `frame` cũ, sang `frame` mới
dựa vào vị trí mới và giá trị `x` này để tính được khoảng cách mà nhân vật đã di chuyển. Từ đó,
tính toán được khoảng cách mới cho các cảnh vật ở phía sau.

Tuy nhiên, lúc này ta đồng thời phải lưu giữ cả `x` và `y`. Ta có thể tạo thêm biến `lastYPosition`,
tuy nhiên, để thuận tiện hơn, ta có thể lưu vào `Vector2`

```csharp
public class CameraController : MonoBehaviour
{
    private Vector2 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 amountToMove = new Vector2(transform.position.x - lastPosition.x, transform.position.y - lastPosition.y);

        farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

        lastPosition = transform.position;
    }
}
```

## 3. Making a Level (tạo các bản đồ)

Tạo bản đồ thông qua công cụ có sẵn của `unity` (`tilemaps`)

### 3.1. Creating a Tile Palette

Tạo 1 cảnh mới, chọn menu `File` > `New scene`

Lưu cảnh lại: chọn `File` > `Save As`, tìm đến thư mục `scenes`, lưu thành `Testing Tile`

Bây giờ mình cần phải vẽ bản đồ mới trên `scene` này, để làm điều đó ta cần phải
có 1 số `tiles` (viên gạch) để có thể vẽ.

Trong thư mục `assets`, di chuyển tới `graphics`, `level art`, `tileset`, tại đây có
1 `sprite` chứa danh sách các `tiles` có thể dùng để vẽ bản đồ.

Ta có thể kéo từng `tile` vào rồi sắp xếp lại để tạo thành bản đồ nhưng như vậy sẽ rất lâu.

![Tile](md_assets/tile.png)

Thay vì làm thủ công từng cái như vậy, ta sẽ dùng `unity tilemaps system` để tạo địa hình
1 cách nhanh chóng.

#### 3.1.1. Tạo titleset

Cần phải tạo `tileset` trước.

Vào `windows` > `2D` > `Tile Palette`, kéo cửa sổ này bên cạnh cửa sổ `Hierarchy`

Nhấn vào nút để tạo 1 `palette` mới, đặt tên `Main Tileset`, lưu vào folder `assets/Tiles`

![Tile palette](md_assets/tilepalette.png)

Cửa sổ hiện tại của `Main Tileset` hiện đang trống, ta tiến hành kéo `tileset` được cung cấp sẵn
trong thư mục `graphics`, `level art`, `tileset` vào đây.

Hệ thống sẽ hỏi nơi muốn lưu trữ các `tiles` chuẩn bị được tạo, chọn thư mục `assets/Tiles`

Sau khi quá trình tạo hoàn tất, ta sẽ có 1 mảng các `tiles` trong cửa sổ `Main Tileset`. Ta có thể dùng
tùy ý các `tiles` này để vẽ địa hình cho `map` mới.

![Done](md_assets/tiledone.png)

Đồng thời, tại thư mục `assets/Tiles`, ta cũng thấy danh sách 1 loạt các `Tiles` được hệ thống tự động
lưu tại đây.

Ta có thể cấu hình 1 số thứ trên các `Tile` này như `Color`, `Collider Type` (nói sau)

### 3.2. Drawing a Level with Tilemaps

Để tạo địa hình 1 cách dễ dàng, ta sẽ dùng đối tượng `Tilemap` có sẵn của `unity`.

Quay lại cửa sổ `Hierarchy`, ta có 2 cách để tạo mới 1 `Tilemap`

- Click chuột phải lên vùng bên trong cửa sổ `Hierarchy`, chọn `Create`
- Chọn Menu `Game Object`, `2D Object`, `Tilemap`

#### 3.2.1. Vẽ địa hình thuần

Sau đó, để tiến hành vẽ địa hình, ta quay lại cửa sổ `Tile Palette`

- Chọn vào 1 `tile` mong muốn rồi qua bên `tilemap` để vẽ
- Có thể chọn công cụ `Rectangle` trong cửa sổ `Tile Palette` để vẽ hình khối chữ nhật (vẽ lòng đất)

Sau khi vẽ xong ta đã có 1 địa hình, tuy nhiên lúc này nó chỉ là ảnh thuần, không hề có bất kỳ 1 hiệu ứng
vật lý nào. Nếu đặt 1 khối tròn ở trên rồi thả cho nó rơi xuống, khối tròn này sẽ đi xuyên qua tấm địa hình
này như chưa hề có gì xảy ra

![Image](md_assets/draw.png)

#### 3.2.2. Thêm `collider` để tấm hình địa hình này có thể tương tác với các `game object` khác

Quay về cửa sổ `Hierarchy`, chọn đối tượng `Tilemap` (`Tilemap` vừa tạo ở trên)

Thêm component `Tilemap Collider 2D`

![Tilemap](md_assets/tilemapcollider2d.png)

Sau khi thêm `component` này vào, ta thấy rõ rất nhiều `collider` được thêm vào và bọc xung quanh mỗi `tile`.
Nếu ta không muốn 1 `tile` được bọc `collider`, chỉ cần cấu hình `tile` đó.

Cách cấu hình 1 `tile` không muốn bọc `collider`

- Click vào `tile` tại đường dẫn `assets/Tiles`
- Tại `collider_type`, chọn `None`

#### 3.2.3. Tối ưu số lượng `collider`

Hiện tại, mỗi `tile` đều được bọc 1 `collider` dẫn đến số lượng `collision` phải check trở nên rất nhiều, gây ra lãng phí
và `lag` game.

Ta có thể gom các `collider` nhỏ này thành 1 thể thống nhất thông qua `component` `Composite Collider 2D`

- Chọn `Tilemap` game object
- Thêm component `Composite Collider 2D`

Sau khi thêm `Composite Collider`, hệ thống sẽ tự thêm vào 1 `Rigidbody 2D`. Nhiệm vụ của `Rigidbody 2D` để check
xem có `collision` nào diễn ra giữa 2 `collider` kề nhau hay không. Nếu kề nhau thì nó gom thành 1 cái, cứ như vậy, tất
cả `collider` kề nhau trong `Tilemap` sẽ được gom thành 1 `collider` lớn.

- Tại component `Tilemap Collider 2D`
- Tick chọn `Used by Composite`

![Composite Collider](md_assets/compositecollider.png)

Lúc này, hệ thống sẽ vẽ các đường nối bên ngoài để tạo thành 1 `collider` lớn, phần bên trong hoàn toàn trống rỗng
và có thể chứa được các `game object` khác. Lúc này, có thể xảy ra tình trạng `Player` bị `lag` và rơi vào vùng rỗng này.

Vì vậy, bây giờ ta sẽ tìm cách để lấp đầy vùng rỗng này.

- Tại `composite collider 2d`
- Chọn `geometry type` thành `polygon`

Lúc này địa hình sẽ trở thành 1 khối vật thể đặc hoàn toàn

![Solid](md_assets/solidcollider.png)

#### 3.2.4. Bỏ hiệu ứng vật lý tác động lên địa hình

Khi thêm `composite collider`, hệ thống tự thêm `rigidbody2d` (để detect collision giữa 2 collider kề nhau, từ đó gom lại).
Lúc này, `rigidbody2d` mang đến các hiệu ứng vật lý, dẫn đến `Tilemap` vừa tạo ra bị trọng lực kéo xuống dưới
màn hình.

Vì vậy, ta cần phải tìm cách để bỏ hiệu ứng vật lý này.

- Tại `rigidbody 2d`
- Chọn `Body type` thành `Kinematic`

![Done](md_assets/tilemapdone.png)

### 3.3. Moving Objects Between Levels with `Prefabs`

Lúc này, ta đã có được 1 địa hình mới thông qua công cụ `Tilemap`.

Tuy nhiên địa hình mới này hoàn toàn không có bất kỳ `Player`, `Background` hay `Middle` nào như màn hình
trước.

Ta có thể thêm thủ công các thứ này bằng tay, sau đó viết `script` và lặp lại 1 mớ logic đã viết trước.

Thay vào đó, ta có thể dùng 1 thứ gọi là `Prefabs` có sẵn trong `unity` để chia sẽ những `game object` chung

- Tạo thư mục `assets/Prefabs`
- Thư mục này chứa các `game object` có thể tái sử dụng được (gọi là 1 `prefab`)

### 3.3.1. Tạo các `game object` có thể tái sử dụng

Để tạo các `prefab`

- Quay lại `scene` hoàn chỉnh lúc đầu tại `assets/Scenes`
- Vào cửa sổ `assets`, chọn `folder` `Prefabs` vừa tạo
- Lần lượt kéo các `game object` cần tái sử dụng vào `folder` này, bao gồm:

  - `Main Camera`: có gắn `script` điều khiển `camera` `CameraController`
  - `Player`: nhân vật chính, có gắn `PlayerController` script
  - `Background`: có ảnh biển và cây cối, làm nền cho `Level` (địa hình)

![Prefab](md_assets/prefab.png)

### 3.3.2. Lưu ý khi điều chỉnh thông số trên `prefab`

Các `prefab` chứa trong thư mục `assets/Prefabs` là các `prefab` gốc.

Các `prefab` được kéo từ thư mục `assets/Prefabs` vào các `scene` là các `prefab` sao chép.

- Khi thay đổi thông số trên `prefab` gốc, tất cả `prefab` sao chép sẽ thay đổi theo
- Khi thay đổi thông số trên `prefab` sao chép, thông số này chỉ ảnh hưởng đến `scene` hiện tại, không ảnh
hưởng đến `prefab` gốc (trừ phi chọn `overrides` để lưu lại thay đổi)

`Prefab` không thể lưu trữ tham chiếu đến các `game object`, do đó khi dùng lại cho các `scene`, ta phải
gán các tham chiếu tương ứng 1 cách thủ công. (Có thể lưu trữ thông qua các bài sau)

### 3.3.3. Sử dụng các `prefabs` vừa được tạo trên `scene` mới

Tại `assets/Scenes`, chọn `scene` vừa tạo có tên `Testing Tilemap`

Kéo các `prefabs` vào cửa sổ `Hierarchy` để sử dụng lại các đối tượng này trong `scene` này.

`Main Camera` đã tồn tại, ta tiến hành xóa `Main Camera` có sẵn và thay thế bằng `Main Camera` trong `Prefab`

Bởi vì `prefab` không lưu trữ tham chiếu nên lúc này ta sẽ phải gán toàn bộ tham chiếu cần thiết 1 cách thủ công.

![Prefabs](md_assets/prefab1.png)

- Đặt lại `sorting layer system` cho đúng để các đối tượng hiển thị 1 cách đúng đắn, đặt `Tilemap` layer thành giá trị `World`
- Đặt lại `layer` đúng để nhân vật hiển thị hoạt họa đúng, `Player` hiển thị hoạt họa nhảy lên khi `Player` đứng trên không trung, cách
xa mặt đất, tuy nhiên, lúc này ta không biết cái gì là mặt đất (thuộc `layer Ground`). Bấm chọn `Tilemap`, đặt giá trị tại `layer` thành `Ground`

![Ground](md_assets/tilemapground.png)

## 4. Health System

### 4.1. Adding Spikers

Thêm 1 số vật cản vào `Level`.

Vào thư mục `assets/2D Platformer Assets/Graphics/Level Mechanics`, tại đây sẽ có 1 số hình
ảnh `spiker`, chọn 1 hình rồi kéo vào `Scene`.

Để `Player` có thể tương tác được với khối `spiker` này, ta cần đặt `collider` vào `spiker`

![Spiker](md_assets/spiker.png)

Trong trường hợp của `spiker`, dùng `box collider` là thích hợp, tuy nhiên cần điều chỉnh lại
kích thước của `box collider` cho phù hợp. (thông qua nút `edit collider`)

Vấn đề người dùng bị cản lại khi lại gần `spiker`

![Image](md_assets/spiker1.png)

Khi `Player` lại gần vật thể `spiker`, họ sẽ bị cản lại bởi `collider`. Để vẫn đảm bảo việc xác
định `collision` giữa `Player` và `spiker`, đồng thời `spiker` không cản `Player`, ta cấu hình như sau:

- Chọn `box collider 2d`
- Tick vào `Is Trigger`

Khi này, `Player` có thể đi xuyên qua `spiker`, tuy nhiên khi `Player` đi vào vùng `trigger` của `spiker`,
hệ thống sẽ thông báo để chúng ta code chức năng trừ điểm sức khỏe của nhân vật.

### 4.2. Creating a Health system

Tạo 1 hệ thống sức khỏe cho nhân vật (có bao nhiêu `trái tim`), khi nhân vật chạm vào các vật cản như `spiker` ở
trên thì điểm sẽ bị trừ. Trừ hết thì `game over`.

Để làm điều đó, ta tiến hành tạo 1 `script` mới, đặt tên `PlayerHealthController`. Sau đó, kéo `script` này vào
đối tượng `Player`.

Đầu tiên, ta tiến hành tạo 1 số biến lưu trữ trạng thái sức khỏe của người chơi

- Số `heart` tối đa
- Số `heart` hiện tại

Bên cạnh đó, ta tiến hành tạo 1 số hàm tiện ích liên quan đến việc kiểm soát số lượng `heart`

- `public void DealDamage()`, được gọi để trừ số `heart` hiện có

```csharp
public void DealDamage()
{
    currentHealth -= 1;

    if (currentHealth <= 0)
    {
        gameObject.SetActive(false);
    }
}
```

Khi hàm này được gọi, nó sẽ giảm `heart` đi 1 đơn vị. Trong trường hợp `heart == 0`, đối tượng `Player`
sẽ bị `deactive`, biến mất khỏi màn hình hiện tại.

- `gameObject` tương tự như `transform`, được `inject` tự động vào `script` bởi `unity`
- `gameObject` giống `this`

### 4.3. Detecting Spikes Hitting The Player

Khi `player` chạm vào `spike`, hàm `DealDamage` sẽ được gọi để trừ số `heart` của `player`.

Ta tiến hành tạo 1 `script` mới, đặt tên `DamagePlayer` và gắn `script` này vào
đối tượng `spikes_white`

Đầu tiên, ta phải xác định được liệu `player` có đi vào vùng của `spikes` hay không (vùng được vẽ bởi `box collider 2d` lúc trước)

- Tiến hành `override` phương thức `OnTriggerEnter2D` tại `DamagePlayer` `scrip`

  ```csharp
  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("Enter collision area");
  }
  ```

- Sử dụng `Debug.Log()` để hiển thị thông tin ra màn hình `console`

Mặc định, trong lần đầu tiên chạy, màn hình `console` hiển thị ra `Enter collision area`. Lý do bởi vì
đã có 1 cái `rigidbody2d` nào đó chạm vào cái `spikes` này. Đó chính là cái `ground`.

Do đó, đầu tiên ta phải kiểm tra xem thứ chạm vào `spikes` có phải là `player` hay không, nếu không phải
là `player` thì bỏ qua.

Tham số truyền vào hàm là 1 biến thuộc kiểu `Collider2D`. Để xác định được đây là đối tượng nào,
ta có thể dùng hệ thống tag (`tag system`) của `unity`.

- Chọn đối tượng `player`, gắn `tag` giá trị `Player`.

  ![Tag](md_assets/tag.png)

- Kiểm tra nếu tham số `other` có `tag` là `Player`

  ```csharp
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Enter collision area");
        }
    }
  ```

### 4.4. Damaging the Player

Khi đã xác định được sự va chạm, giờ là lúc tắm máu người dùng

Có 1 số cách để thực hiện việc này.

- Khi va chạm xảy ra, ta tiến hành tìm kiếm `game object`, sao cho `game object` này chứa `script` `PlayerHealthController`

  ```csharp
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
          var player = FindObjectOfType<PlayerHealthController>();
          player.DealDamage();
        }
    }
  ```

- Tạo `singleton` cho `script` `PlayerHealthController`

  ```csharp
    public class PlayerHealthController : MonoBehaviour
    {
        public static PlayerHealthController instance;

        public int currentHealth, maxHealth;

        // Happens right before the Start() function
        private void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
        }

        // Update is called once per frame
        void Update() { }

        public void DealDamage()
        {
            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
  ```

  Truy cập trực tiếp đến `instance` và gọi hàm `DealDamage()`

  ```csharp
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();
        }
    }
  ```

### 4.5. Setting up Health UI

Sau khi đã xong phần xác định va chạm và trừ `heart` nhân vật. Lúc này, ta cần có
1 phương pháp nào đó để hiển thị số `heart` còn lại lên màn hình cho người chơi biết.

Để hiển thị số `heart`, ta sẽ dùng hệ thống `canvas` có sẵn của `unity`.

- Bấm chuột phải lên vùng `Hierarchy`
- Chọn `UI` > `Canvas`
- Nhấp đôi chuột lên cái `Canvas` này, ta sẽ thấy toàn bộ vùng vẽ
- Đôi lúc, khung này sẽ bị ẩn, đây là tính năng ẩn hiện `layer` của `unity`, để xem chi tiết,
ta chọn vào đối tượng `Canvas`, chọn `dropdown` `Layers` và bấm vào biểu tượng con mắt.

![Canvas](md_assets/canvas.png)

Khi tạo 1 `canvas` mới, hệ thống sẽ tự tạo kèm 1 cái `EventSystem`

- Khi ta thêm 1 `button` vào `canvas`
- Để truy cập đến `button` này, ta phải thông qua `EventSystem`

Để tiện lợi trong việc tạo `prefab` cũng như tái sử dụng `canvas`, ta thường để `EventSystem` trở thành con của `Canvas`

![Event System](md_assets/eventsystem.png)

Lớp `canvas` vừa được tạo ra khá lớn, nó che hết phần màn hình thiết kế. Tuy nhiên, nó lại như 1 lớp phủ lên màn hình `in game` ở phía
dưới.

Đưa `heart` vào `canvas`

- Chọn `heart sprite` tại `assets/2D Platformer Assets/Graphics/UI`
- Kéo `heart` vào trở thành 1 con của `Canvas`, lúc này `heart` đã xuất hiện tại màn hình `in game`. Tuy nhiên, tại màn hinh `canvas`,
`heart` lại quá nhỏ đến mức không thấy được.
- Thay vào đó, chọn đối tượng `Canvas`, chuột phải, chọn `Create` > `Image` (đổi tên thành `Heart1`)
- Kéo `sprite` `heart` vào thuộc tính `Source Image` của `Heart1`
- Chọn `Set Native Size` để đặt đúng kích thước gốc của `sprite Heart`

- Kéo `Heart` về góc và `duplicate` thêm 2 `Heart` nữa
  ![Hearts](md_assets/hearts.png)

Cấu hình `Heart` khi `unity` `scale` kích thước màn hình

- Chọn cùng lúc 3 `Heart`, dùng công cụ `Anchor` để móc nó vào góc trên bên trái.

  ![Anchor](md_assets/ancrhor.png)

- `scale` kích thước của `Heart` khi kích thước màn hình thay đổi

  - Chọn đối tượng `Canvas`
  - Chọn thuộc tính `UI Scale Mode` thành `Scale With Screen Size`
  - Đặt kích thước `Reference Resolution` thành `1920 x 1080` (ứng với kích thước màn hình `dev` hiện tại)

  ![Scale](md_assets/scale.png)

### 4.6. Updating Heart UI

Đã có giao diện `Heart` được vẽ thông qua công cụ `Canvas` và được tối ưu hiển thị thông qua việc dùng mỏ neo `anchor` và `scale mode`.

Lúc này, ta cần có giải pháp để cập nhật trạng thái hiển thị của `Heart`

Tạo 1 `script` mới để kiểm soát việc hiển thị `Heart`. Thông thường, với mỗi đối tượng, ta sẽ tạo 1 `script` riêng biệt để quản lý.

- Chọn folder `scripts`, tạo script mới đặt tên `UIController`
- Gắn `script` này vào đối tượng `Canvas`

Để thay đổi việc hiển thị `Heart` trên `UI`, ta cần xác định các đối tượng liên quan để tiến hành tham chiếu tới

- 3 khung `Image` bên trong `Canvas`
- 2 `Sprite` hiển thị trạng thái `Heart Full` và `Heart Empty`

Ta cần truyền tham chiếu đến 5 thứ này vào `UIController`

```csharp
  public UnityEngine.UI.Image heart1, heart2, heart3;
  public Sprite heartFull, heartEmtpty;
```

![Heart](md_assets/hearts1.png)

Sau đó, dựa vào số lượng `Heart` còn lại, ta sẽ hiển thị tương ứng.

- Dùng `heart.sprite = sprite` để thay đổi `sprite` bên trong mỗi khung `Image`

Bên cạnh đó, để tiện truy cập vào các phương thức bên trong `UIController`, ta áp dụng mẫu `singleton` cho `class` này.

```csharp
public class UIController : MonoBehaviour
{
    public static UIController instance;

    public UnityEngine.UI.Image heart1, heart2, heart3;
    public Sprite heartFull, heartEmtpty;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthDisplay()
    {
        switch (PlayerHealthController.instance.currentHealth)
        {
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmtpty;

                break;

            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmtpty;
                heart3.sprite = heartEmtpty;

                break;

            case 0:
                heart1.sprite = heartEmtpty;
                heart2.sprite = heartEmtpty;
                heart3.sprite = heartEmtpty;

                break;

            default:
                heart1.sprite = heartEmtpty;
                heart2.sprite = heartEmtpty;
                heart3.sprite = heartEmtpty;

                break;
        }
    }
}
```

Sau khi đã có phương thức cập nhật `Heart` trên giao diện, ta tiến hành gọi phương thức này
khi `Player` chạm vào `spikes`

```csharp
public void DealDamage()
{
    currentHealth -= 1;

    if (currentHealth <= 0)
    {
        currentHealth = 0;
        gameObject.SetActive(false);
    }

    UIController.instance.UpdateHealthDisplay();
}
```

![Heart](md_assets/hearts2.png)

### 4.7. Show half hearts

Sau khi đã hiển thị 2 dạng `heart` là `full heart` và `empty heart`. Lúc này,
ta sẽ thử thách bản thân với `half heart`

- Đặt giá trị `maxHealth` lên thành `6`
- Không tạo `6 Image` để chứa `6 Heart`
- Có `6` giá trị, ta có thể đưa `half heart` vào

```csharp
  public void UpdateHealthDisplay()
  {
      switch (PlayerHealthController.instance.currentHealth)
      {
          case 6:
              heart1.sprite = heartFull;
              heart2.sprite = heartFull;
              heart3.sprite = heartFull;

              break;

          case 5:
              heart1.sprite = heartFull;
              heart2.sprite = heartFull;
              heart3.sprite = heartHalf;

              break;

          case 4:
              heart1.sprite = heartFull;
              heart2.sprite = heartFull;
              heart3.sprite = heartEmtpty;

              break;

          case 3:
              heart1.sprite = heartFull;
              heart2.sprite = heartHalf;
              heart3.sprite = heartEmtpty;

              break;

          case 2:
              heart1.sprite = heartFull;
              heart2.sprite = heartEmtpty;
              heart3.sprite = heartEmtpty;

              break;

          case 1:
              heart1.sprite = heartHalf;
              heart2.sprite = heartEmtpty;
              heart3.sprite = heartEmtpty;

              break;

          default:
              heart1.sprite = heartEmtpty;
              heart2.sprite = heartEmtpty;
              heart3.sprite = heartEmtpty;

              break;
      }
  }
```

![Heart Half](md_assets/heafthafl.png)

### 4.8. Adding Invicibility

Khi chúng ta xếp 1 dàn bẫy chông (`spikes`) kề nhau, người dùng đi qua hết loạt bẫy này sẽ bị trừ sạch `heart`.
Hoặc khi người dùng nhảy vào trúng điểm giao giữa 2 cái bẫy chông cũng sẽ bị trừ 2 `heart`. Điều này mang lại cảm
giác khá tệ khi chơi game. Do đó, giờ ta sẽ thêm tính năng `invicibility`, khi người dùng va vào bẫy chông, họ
chỉ bị trừ 1 điểm `heart`. Sau 1 khoảng thời gian, nếu va phải 1 `spike` khác thì họ mới tiếp tục bị trừ điểm.

Tính năng này sẽ được thêm vào `PlayerHealthController` bởi vì `script` này chứa code liên quan đến việc kiểm
soát trạng thái `heart` của người chơi.

Ta cần tạo 1 số biến:

- `invincibleLength`: thời gian người chơi miễn nhiễm
- `invincibleCounter`: đếm ngược thời gian miễn nhiễm

Khi đã có 2 biến này, ta tiến hành xử lý `logic`

- Tại phương thức `DealDamage`, nếu thời gian `invincibleCounter <= 0` thì ta tiến hành đặt `invincibleCounter = invincibleLength` và trừ `heart`
- Khi `invincibleCounter > 0` nghĩa là người chơi đang trong giai đoạn miễn nhiễm, ta không trừ `heart`
- Tiếp đó, ta cần 1 giải pháp để giảm `invincibleCounter` sau mỗi lần `update frame`, cách tốt nhất là trừ
giá trị `invincibleCounter` với giá trị `Time.DeltaTime`, trong đó `DeltaTime` là thời gian cần thiết
trong mỗi lần `frame update`.
  
  - Nếu `60FPS`, `deltaTime` = `1/60` (phút)
  - Nếu `30FPS`, `deltaTIme` = `1/30` (phút)

```csharp
  void Update()
  {
      if (invincibleCounter > 0)
          invincibleCounter -= Time.deltaTime;
  }

  public void DealDamage()
  {
      if (invincibleCounter <= 0)
      {
          currentHealth -= 1;

          if (currentHealth <= 0)
          {
              currentHealth = 0;
              gameObject.SetActive(false);
          }
          else
          {
              invincibleCounter = invincibleLength;
          }

          UIController.instance.UpdateHealthDisplay();
      }
  }
```
