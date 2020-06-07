﻿/*==============================================================*/
/* ST7-N15														*/
/* script tạo dữ liệu thiết kế dữ liệu			                */
/* Created on:     11/14/2019 1:57:38 PM                        */
/*==============================================================*/


/* mọi người lấy file sript về tạo database thôi, còn muốn chỉnh sửa phải hỏi nhóm*/
--use [master]
--go
create database[tiki]
go
use [tiki]
go
create table LOAIHANG(
	id_loaihang varchar(20) primary key,
	tenloaihang varchar(50) not null
)
go

create table NGUOIBAN(
	id_nguoiban varchar(20) primary key,
	id_loaihang varchar(20),
	tennguoiban nvarchar(50) not null,
	sdtnguoiban int not null,
	emailnguoiban varchar(30) not null,
	tencuahang varchar(30) not null,
	linkcuahang varchar(50) not null,
	giayphep bit,
	masokinhdoanh varchar(20),
	tinh_tp nvarchar(30),
	constraint fk_nguoiban_loaihang
	foreign key (id_loaihang)
	references LOAIHANG(id_loaihang)
)
go

create table DAILY(
	id_daily varchar(20) primary key,
	id_nguoiban varchar(20),
	diachi nvarchar(100),
	thanhpho nvarchar(30) not null,
	constraint fk_daily_nguoiban
	foreign key (id_nguoiban)
	references NGUOIBAN(id_nguoiban)
)
go

create table SANPHAM(
	id_sanpham varchar(20) primary key,
	id_loaihang varchar(20),
	tensanpham nvarchar(100) not null,
	hang nvarchar(30),
	thongtinchitiet nvarchar(500),
	danhgiatrungbinh float(4),
	gia int not null,
	giagoc int,
	constraint fk_sanpham_loaihang
	foreign key (id_loaihang)
	references loaihang(id_loaihang)
)
go

create table CHITIETHANG_DAILY(
	id_sanpham varchar(20),
	id_daily varchar(20),
	soluong int not null,
	constraint pk_chitiethang_daily
	primary key(id_sanpham,id_daily),
	constraint fk_chitiethang_daily_daily
	foreign key (id_daily)
	references DAILY(id_daily),
	constraint fk_chitiethang_daily_sanpham
	foreign key (id_sanpham)
	references SANPHAM(id_sanpham)
)
go

create table NHANVIENGIAOHANG(
	id_nhanvien varchar(20) primary key,
	tennhanvien nvarchar(50) not null,
	sdt int,
	diachi nvarchar(100),
	gioitinh nvarchar(10),
	ngaysinh datetime,
	cmnd int unique,
	constraint check_gioitinh check (gioitinh in(null,'Nam','Nữ'))
)
go

create table KHACHHANG(
	id_khachhang varchar(20) primary key,
	tenkhachhang nvarchar(50) not null,
	sdt int not null,
	email varchar(30) not null,
	gioitinh nvarchar(10),
	ngaysinh datetime,
	constraint chech_khachhang check (gioitinh in (null,'Nam','Nữ'))

)
go

create table DANHGIA(
	id_khachhang varchar(20),
	id_sanpham varchar(20),
	stt int,
	sao int not null,
	danhgia nvarchar(50),
	danhgiachitiet nvarchar(500),
	constraint pk_danhgia primary key (id_khachhang,id_sanpham, stt),
	constraint fk_danhgia_khachhang
	foreign key (id_khachhang)
	references KHACHHANG(id_khachhang),
	constraint fk_danhgia_sanpham
	foreign key (id_sanpham)
	references SANPHAM(id_sanpham)
)
go

create table BINHLUAN(
	id_sanpham varchar(20),
	id_khachhang varchar(20),
	stt int,
	binhluan nvarchar(500),
	constraint pk_binhluan primary key (id_sanpham,id_khachhang,stt),
	constraint fk_binhluan_khachhang
	foreign key (id_khachhang)
	references KHACHHANG(id_khachhang),
	constraint fk_binhluan_sanpham
	foreign key (id_sanpham)
	references SANPHAM(id_sanpham)
)
go

create table DIACHIGIAOHANG(
	id_khachhang varchar(20),
	stt int,
	hovaten nvarchar(50) not null,
	sdt int not null,
	tinh_thanhpho nvarchar(30) not null,
	quan_huyen nvarchar(30) ,
	phuong_xa nvarchar(30),
	diachi nvarchar(100) not null,
	loaidiachi varchar(30),
	macdinh bit,
	constraint pk_diachigiaohang primary key(id_khachhang,stt),
	constraint check_loaidiachi check(loaidiachi in(null,'Nhà riêng / Chung cư','Cơ quan / Công ty')),
	constraint fk_diachigiaohang_khachhang
	foreign key (id_khachhang)
	references KHACHHANG(id_khachhang)
)
go

create table GIOHANG(
	id_khachhang varchar(20) primary key,
	tongsanpham int,
	tamtinh int,
	thanhtien int,
	constraint fk_giohang_khachhang
	foreign key(id_khachhang)
	references KHACHHANG(id_khachhang)
)
go

create table CHITIETGIOHANG(
	id_sanpham varchar(20),
	id_khachhang varchar(20),
	soluong int,
	constraint pk_chitietgiohang primary key(id_sanpham,id_khachhang),
	constraint fk_chitietgiohang_giohang
	foreign key (id_khachhang)
	references GIOHANG(id_khachhang),
	constraint fk_chitietgiohang_sanpham
	foreign key (id_sanpham)
	references SANPHAM(id_sanpham)
)
go

create table DONHANG(
	id_donhang varchar(20) primary key,
	id_nhanvien varchar(20),
	id_khachhang varchar(20),
	stt int,
	SoLuongSP int,
	ngaymua datetime not null,
	hinhthucgiaohang nvarchar(20),
	hinhthucthanhtoan nvarchar(20),
	trangthai nvarchar(30),
	tamtinh int,
	tongtien int,
	phuphi int,
	phivanchuyen int,
	constraint fk_donhang_diachigiaohang
	foreign key (id_khachhang, stt)
	references DIACHIGIAOHANG(id_khachhang,stt),
	constraint fk_donhang_nhanviengiaohang
	foreign key (id_nhanvien)
	references NHANVIENGIAOHANG(id_nhanvien),
	constraint check_hinhthucgiaohang check(hinhthucgiaohang in(null,'Giao hàng tiêu chuẩn','Tikinow')),
	constraint check_hinhthucthanhtoan check(hinhthucthanhtoan in( null,'Tiền mặt','Thẻ','Momo')),
	constraint check_trangthai check (trangthai in(null,'Đặt hàng thành công','Đã hủy','Đang giao','Giao thành công'))
)
go
create table CHITIETDONHANG(
	id_sanpham varchar(20),
	id_donhang varchar(20),
	soluong int,
	dongia int,
	trangthai_ct nvarchar(30),
	constraint pk_chitietdonhang primary key(id_sanpham,id_donhang),
	constraint fk_chitietdonhang_sanpham
	foreign key (id_sanpham)
	references SANPHAM(id_sanpham),
	constraint fk_chitietdonhang_donhang
	foreign key (id_donhang)
	references DONHANG(id_donhang),
	constraint check_trangthai_ct check (trangthai_ct in(null,'Đặt hàng thành công','Đã hủy','Đang giao','Giao thành công'))
)
CREATE TABLE nguoiban_sanpham(
id_sanpham varchar(20),
id_nguoiban VARCHAR(20),
CONSTRAINT pk_nguoiban_sanpham PRIMARY KEY(id_sanpham,id_nguoiban),
CONSTRAINT fk_sanpham_nguoiban_sanpham FOREIGN KEY (id_sanpham) REFERENCES dbo.SANPHAM(id_sanpham),
CONSTRAINT fk_sanpham_nguoiban_nguoiban FOREIGN KEY (id_nguoiban) REFERENCES dbo.NGUOIBAN(id_nguoiban)
)
CREATE NONCLUSTERED INDEX index_loaihang_nguoiban ON dbo.NGUOIBAN(id_loaihang)
CREATE NONCLUSTERED INDEX index_nguoiban_daily ON dbo.DAILY(id_nguoiban)
CREATE NONCLUSTERED INDEX index_loaihang_sanpham ON dbo.SANPHAM(id_loaihang)
CREATE NONCLUSTERED INDEX index_sao_danhgia ON dbo.DANHGIA(sao)
create trigger trg_ThemVaoGioHang
on CHITIETGIOHANG
for insert
as
begin
	declare @soluonggoc int
	declare @soluongmua int
	select @soluonggoc =CHITIETHANG_DAILY.soluong from CHITIETHANG_DAILY, inserted where inserted.id_sanpham=CHITIETHANG_DAILY.id_sanpham
	select @soluongmua= inserted.soluong from inserted
	if(@soluongmua>@soluonggoc)
	begin
		raiserror('số lượng không được vượt quá số lượng trong đại lý',1,1)
		rollback tran
	end
	else
	begin
		update dbo.CHITIETHANG_DAILY set soluong=@soluonggoc-@soluongmua from CHITIETHANG_DAILY,inserted where inserted.id_sanpham=CHITIETHANG_DAILY.id_sanpham
	end
end
go
/*trigger tự động thay đổi trạng thái của chi tiết đơn hàng khi trạng thái đơn hàng thay đổi*/
create trigger trg_ThayDoiTrangThaiChiTietDonHang
on DONHANG
for insert, update
as
begin
	declare  @trangthai nvarchar(30)
	select @trangthai=inserted.trangthai from inserted
	update CHITIETDONHANG set trangthai_ct=@trangthai from CHITIETDONHANG, inserted where CHITIETDONHANG.id_donhang=inserted.id_donhang
end
go
/*khách hàng chỉ có 1 địa chỉ mặc định( khi set mặc định địa chỉ này thì các địa chỉ khác sẽ không mặc định nữa*/
create trigger trg_DiaChiMacDinh
on DIACHIGIAOHANG
for insert, update
as
begin
	declare @macdinh bit
	select @macdinh=macdinh from inserted
	if (@macdinh=1)
	begin
		update DIACHIGIAOHANG set macdinh=0 from DIACHIGIAOHANG, inserted where	DIACHIGIAOHANG.id_khachhang=inserted.id_khachhang AND DIACHIGIAOHANG.stt != inserted.stt
	end
end
go

/* trigger tự động cộng lại số lượng hàng vào trong đại lý khi đơn hàng bị hủy */
create trigger trg_Huy
on CHITIETDONHANG
for update
as
begin
	declare @trangthai_ct nvarchar(30)
	select @trangthai_ct=inserted.trangthai_ct from inserted
	if(@trangthai_ct= 'Đã hủy')
	begin
		declare @soluonggoc int
		declare @soluonghuy int
		select @soluonggoc =CHITIETHANG_DAILY.soluong from CHITIETHANG_DAILY, inserted where inserted.id_sanpham=CHITIETHANG_DAILY.id_sanpham
		select @soluonghuy= inserted.soluong from inserted
		update dbo.CHITIETHANG_DAILY set soluong=@soluonggoc+@soluonghuy from CHITIETHANG_DAILY,inserted where inserted.id_sanpham=CHITIETHANG_DAILY.id_sanpham
	end
end
go
go
--=========================================================================================================
create proc usp_DatHang @MaKhach varchar(20), @ma_NV varchar(20), @ten nvarchar(50), @sdt int, @tinh nvarchar(30), @huyen nvarchar(30),
    @xa nvarchar(30), @diachi nvarchar(100), @loai varchar(30), @giao varchar(20), @thanhToan varchar(20), @phuPhi int
as
   if(not exists(select * from KHACHHANG where @MaKhach = id_khachhang))
   begin 
      raiserror('Chua dang ki khach hang.',1,1)
	  return
   end
   if((select tongsanpham from GIOHANG where id_khachhang = @MaKhach) = 0 or (not exists(select * from GIOHANG where id_khachhang = @MaKhach)))
   begin
      raiserror('Chua chon hang de mua.',1,1)
	  return
   end
   -- Them dia chi giao hang
   declare @stt_dc int
   select @stt_dc = count(*) from DIACHIGIAOHANG where id_khachhang=@MaKhach and hovaten=@ten and sdt=@sdt and tinh_thanhpho=@tinh
     and quan_huyen=@huyen and phuong_xa=@xa and diachi=@diachi
   if(@stt_dc=0)
   begin 
      raiserror('null -----------------------------------',1,1)
      set @stt_dc = 1 + (select count(*) from DIACHIGIAOHANG where id_khachhang=@MaKhach)
	  insert into DIACHIGIAOHANG(id_khachhang, stt, hovaten, sdt, tinh_thanhpho, quan_huyen, phuong_xa, diachi, loaidiachi)
	  values(@MaKhach, @stt_dc, @ten, @sdt, @tinh, @huyen, @xa, @diachi, @loai)
   end

   --them don dat hang
   declare @maDon varchar(20), @phiVanChuyen int
   set @maDon = @MaKhach + '_DH' + convert(char, (select count(*) from DONHANG where id_khachhang = @MaKhach))
   declare @ngay datetime, @TongSoSP int
   set @TongSoSP = (select tongsanpham from GIOHANG where id_khachhang=@MaKhach)
   set @ngay = getdate()
   if(@giao = 'Giao hàng tiêu chuẩn') set @phiVanChuyen = 0
   else if(@giao = 'Tikinow') set @phiVanChuyen = 29000
   insert into DONHANG(id_donhang,id_nhanvien,id_khachhang,stt,SoLuongSP,ngaymua,hinhthucgiaohang,hinhthucthanhtoan,phuphi,phivanchuyen)
          values (@maDon, @ma_NV, @MaKhach, @stt_dc, @TongSoSP, @ngay, @giao, @thanhToan, @phuPhi, @phiVanChuyen)
   SELECT * FROM dbo.DONHANG
   declare @Ma_sp varchar(20), @gia int, @soLuong int
   --them chi tiet don dat hang
   while(@TongSoSP > 0)
   begin
       set @Ma_sp = (select MIN(id_sanpham) from CHITIETGIOHANG where id_khachhang=@MaKhach)
	   set @soLuong = (select soluong from CHITIETGIOHANG where id_khachhang = @MaKhach and id_sanpham = @Ma_sp)
	   select @gia = gia from SANPHAM where id_sanpham = @Ma_sp
	   insert into CHITIETDONHANG(id_donhang, id_sanpham, dongia, soluong, trangthai_ct) values (@maDon, @Ma_sp, @gia, @soLuong, 'Đặt hàng thành công')
	   update GIOHANG set tongsanpham = tongsanpham - @soLuong where id_khachhang= @MaKhach
	   delete from CHITIETGIOHANG where id_khachhang = @MaKhach and id_sanpham = @Ma_sp
	   set @TongSoSP = @TongSoSP - @soLuong
   end
   --cap nhat tong tien cua donn dat hang
   declare @thanhTien int, @Tong int
   select @thanhTien = SUM(dongia*soluong) from CHITIETDONHANG where id_donhang = @maDon
   set @Tong = @thanhTien + @phuPhi + @phiVanChuyen
   update DONHANG set tamtinh = @thanhTien, tongtien = @Tong, trangthai = 'Đặt hàng thành công'
   where id_donhang= @maDon
   update GIOHANG set tongsanpham=0, tamtinh=0, thanhtien=0 where id_khachhang = @MaKhach
GO

-- chinh sua don: huy 1 sp trong don, thay doi noi giao hang
create proc usp_HuyDat_1_sp @MaDon varchar(20), @MaSP varchar(20), @soLuongHuy int
as
   if(@soLuongHuy <= 0)
   begin 
      raiserror('So luong huy khong hop le',1,1)
	  return
   end
   if(not exists(select * from CHITIETDONHANG where id_donhang = @MaDon and id_sanpham = @MaSP))
   begin 
      raiserror('Chua dat san pham tren',1,1)
	  return
   end
   if((select trangthai_ct from CHITIETDONHANG where id_donhang = @MaDon) in ('Đang giao','Giao thành công') )
   begin
      raiserror('Khong huy duoc. Muon roi!',1,1)
	  return 
   end
   declare @SL_Dat int
   set @SL_Dat = (select soluong from CHITIETDONHANG where id_donhang = @MaDon and id_sanpham = @MaSP)
   if(@soLuongHuy >= @SL_Dat) 
   begin
      set @soLuongHuy = @SL_Dat
	  delete from CHITIETDONHANG where id_donhang = @MaDon and id_sanpham = @MaSP
	  SELECT *FROM dbo.GIOHANG
   end 
   else
      update CHITIETDONHANG set soluong = soluong - @soLuongHuy where id_donhang = @MaDon and id_sanpham = @MaSP
   update DONHANG set SoLuongSP = SoLuongSP - @soLuongHuy where id_donhang = @MaDon
   if((select SoLuongSP from DONHANG where id_donhang = @MaDon) = 0)
   BEGIN
      delete from DONHANG where id_donhang = @MaDon
	  SELECT * FROM dbo.DONHANG
   END

GO
create proc usp_DoiNoiGiao @MaDon varchar(20), @ten nvarchar(50), @sdt int, @tinh nvarchar(30),
                @huyen nvarchar(30), @xa nvarchar(30), @diachi nvarchar(100), @loai varchar(30)
as
   if(@ten= null or @sdt = null or @tinh = null or @diachi = null)
   begin 
      raiserror('khong duoc de trong cac muc bat buoc',1,1)
	  return
   end
   if (not exists(select * from DONHANG where id_donhang = @MaDon))
   begin 
      raiserror('Khong co don hang.',1,1)
	  return
   end
    if((select trangthai_ct from CHITIETDONHANG where id_donhang = @MaDon) in ('Đang giao','Giao thành công') )
   begin
      raiserror('Khong thay doi duoc. Muon roi!!!',1,1)
	  return
   end
   declare @stt int, @MaKhach varchar(20)
   select @MaKhach = id_khachhang from DONHANG where id_donhang = @MaDon 
   select @stt = stt from DIACHIGIAOHANG where id_khachhang=@MaKhach and hovaten=@ten and sdt=@sdt and tinh_thanhpho=@tinh
     and quan_huyen=@huyen and phuong_xa=@xa and diachi=@diachi
   if(@stt=null)
   begin 
      set @stt = 1 + (select MAX(stt) from DIACHIGIAOHANG where id_khachhang=@MaKhach)
	  insert into DIACHIGIAOHANG(id_khachhang, stt, hovaten, sdt, tinh_thanhpho, quan_huyen, phuong_xa, diachi, loaidiachi)
	  values(@MaKhach, @stt, @sdt, @ten, @tinh, @huyen, @xa, @diachi, @loai)
   end
   update DONHANG set stt = @stt where id_donhang = @MaDon
go

create proc usp_HuyDon @MaDon varchar(20)
as
   if (not exists(select * from DONHANG where id_donhang = @MaDon))
   begin 
      raiserror('Khong co don hang.',1,1)
	  return
   end
   if((select trangthai from DONHANG where id_donhang = @MaDon) in ('Đang giao','Giao thành công') )
   begin
      raiserror('Khong huy don duoc. Muon roi',1,1)
	  return 
   end
   if((select trangthai from DONHANG where id_donhang = @MaDon) = 'Đã hủy')
   begin
      raiserror('Don da huy tu truoc',1,1)
	  return 
   end 
   --delete from CHITIETDONHANG where id_donhang = @MaDon
   --delete from DONHANG where id_donhang = @MaDon
   update CHITIETDONHANG set trangthai_ct = 'Đã hủy' where id_donhang = @MaDon
   update DONHANG set trangthai = 'Đã hủy' where id_donhang = @MaDon
go

create proc usp_TinhTrangGiao @MaDon varchar(20)
as
   if (not exists(select * from DONHANG where id_donhang = @MaDon))
   begin 
      raiserror('Khong co don hang.',1,1)
	  return
   end
   select DH.id_donhang as MaDon, CT.id_sanpham as SanPham, ct.trangthai_ct as TrangThaiGiaoHang, DH.hinhthucgiaohang as HinhThucThanhToan
   from CHITIETDONHANG CT, DONHANG DH 
   where DH.id_donhang = @MaDon and DH.id_donhang = CT.id_donhang
go
exec usp_TinhTrangGiao dh2
--giao thanh cong khi khach da nhan hang va thanh toan, co bao gom danh gia
create proc usp_ThanhToan @MaDon varchar(20), @MaHang varchar(20), @SoSao int, @DG varchar(50), @DGCT varchar(500)
--khi SoSao < 0 nghia la khach ko muon danh gia
as
   if(not exists(select * from CHITIETDONHANG where id_donhang = @MaDon and id_sanpham = @MaHang))
   begin
      raiserror('Ma don khong dung hoac ma san pham khong dung',1,1)
	  return
   end
   if((select trangthai_ct from CHITIETDONHANG where id_donhang = @MaDon and id_sanpham = @MaHang)='Đã hủy')
   begin
      raiserror('Loi! Don da bi huy',1,1)
	  return
   end
   update CHITIETDONHANG set trangthai_ct = 'Giao thành công' where id_donhang = @MaDon and id_sanpham = @MaHang
   if(@SoSao < 0) return
   if(@SoSao > 5) set @SoSao = 5
   declare @MaKhach varchar(20), @stt int
   select @MaKhach = id_khachhang from DONHANG where id_donhang = @MaDon
   set @stt = 1 + (select count(*) from DANHGIA where id_khachhang = @MaKhach and id_sanpham = @MaHang)
   insert into DANHGIA(id_khachhang, id_sanpham, stt, sao, danhgia, danhgiachitiet)
           values (@MaKhach, @MaHang, @stt, @SoSao, @DG, @DGCT)

   declare @tb float(4)
   set @tb = (select AVG(sao) from DANHGIA where id_sanpham = @MaHang)
   update SANPHAM set danhgiatrungbinh = @tb where id_sanpham = @MaHang

   if(exists(select * from CHITIETDONHANG where id_donhang = @MaDon and trangthai_ct != 'Giao thành công'))
       update DONHANG set trangthai = 'Đang giao hàng' where id_donhang = @MaDon
   else 
       update DONHANG set trangthai = 'Giao thành công' where id_donhang = @MaDon
go
create proc usp_ThemCmt @MaKhach varchar(20), @MaSP varchar(20), @NoiDung varchar(500)
as
   if(not exists(select * from KHACHHANG where id_khachhang = @MaKhach))
   begin
      raiserror('Khach tao lao.',1,1)
	  return
   end
   if(not exists(select * from SANPHAM where id_sanpham = @MaSP))
   begin
      raiserror('Khong co san pham do.',1,1)
	  return
   end
   declare @stt int
   set @stt = (select count(*) from BINHLUAN where id_khachhang = @MaKhach and id_sanpham = @MaSP)
   insert into BINHLUAN(id_khachhang, id_sanpham, stt, binhluan) values (@MaKhach, @MaSP, @stt, @NoiDung)
go

create proc usp_ThemVaoGio @MaKhach varchar(20), @MaSP varchar(20), @soLuong int
as
   if(not exists(select * from KHACHHANG where id_khachhang = @MaKhach))
   begin
      raiserror('Khach tao lao.',1,1)
	  return
   end
   if(not exists(select * from SANPHAM where id_sanpham = @MaSP))
   begin
      raiserror('Khong co san pham do.',1,1)
	  return
   end
   declare @tien int 
   set @tien = @soLuong*(select gia from SANPHAM where id_sanpham = @MaSP)
   update GIOHANG set tongsanpham = tongsanpham + @soLuong, tamtinh = tamtinh + @tien, thanhtien = thanhtien + @tien
      where id_khachhang = @MaKhach
   insert into CHITIETGIOHANG(id_khachhang, id_sanpham, soluong) values(@MaKhach, @MaSP, @soLuong)
go
create proc usp_BoSPKhoiGio @MaKhach varchar(20), @MaSP varchar(20), @soLuong int
as
   if(not exists(select * from KHACHHANG where id_khachhang = @MaKhach))
   begin
      raiserror('Khach tao lao.',1,1)
	  return
   end
   if(not exists(select * from SANPHAM where id_sanpham = @MaSP))
   begin
      raiserror('Khong co san pham do.',1,1)
	  return
   end
   if(not exists(select * from CHITIETGIOHANG where id_khachhang= @MaKhach and id_sanpham = @MaSP))
   begin 
      raiserror('Khach khong co san pham tren trong gio.',1,1)
	  return
   end
   declare @sl int
   set @sl = (select soluong from CHITIETGIOHANG where id_khachhang = @MaKhach and id_sanpham = @MaSP)
   if(@sl - @soLuong > 0)
      update CHITIETGIOHANG set soluong = @sl - @soLuong where id_khachhang = @MaKhach and id_sanpham = @MaSP
   else
   begin
      delete from CHITIETGIOHANG where id_khachhang = @MaKhach and id_sanpham = @MaSP
	  set @soLuong = @sl
   end
   declare @tien int 
   set @tien = @soLuong*(select gia from SANPHAM where id_sanpham = @MaSP)
   update GIOHANG set tongsanpham = tongsanpham - @soLuong, tamtinh = tamtinh - @tien, thanhtien = thanhtien - @tien
         where id_khachhang = @MaKhach
go
create proc usp_Dk_Khach  @tenKhachHang nvarchar(50), @sdt int, @email varchar(30), @gioitinh nvarchar(10), @NS datetime
as 
   if(exists (select * from KHACHHANG where email = @email))
   begin
      raiserror('email da dang ki roi.',1,1)
	  return
   end
   declare @MaKhach varchar(20)
   set @MaKhach = 'K' + CONVERT(char, 1 + (select count(*) from KHACHHANG))
   insert into KHACHHANG(id_khachhang, tenkhachhang, sdt, email, gioitinh, ngaysinh)
   values(@MaKhach, @tenKhachHang, @sdt, @email, @gioitinh, @NS)
   insert into GIOHANG(id_khachhang, tongsanpham,tamtinh,thanhtien) values(@MaKhach, 0, 0, 0)
go
CREATE PROCEDURE timkiemtheoten(@chuoi nvarchar(50))
as
BEGIN
SELECT dbo.SANPHAM.id_sanpham,dbo.SANPHAM.tensanpham
FROM dbo.SANPHAM 
WHERE dbo.SANPHAM.tensanpham LIKE '%'+@chuoi+'%'
END
CREATE PROCEDURE timkiemtheohang(@chuoi nvarchar(50))
AS 
BEGIN 
SELECT dbo.SANPHAM.id_sanpham,dbo.SANPHAM.tensanpham
FROM dbo.SANPHAM
WHERE (dbo.SANPHAM.hang LIKE '%'+ @chuoi +'%') 
END
CREATE PROCEDURE timkiemtheogiatien(@gia1 int,@gia2 int)
AS
BEGIN
IF(@gia1 IS NULL)
SET @gia1=0
IF(@gia2 IS NULL)
SET @gia2=(SELECT MAX(dbo.SANPHAM.gia)FROM dbo.SANPHAM)
SELECT dbo.SANPHAM.id_sanpham,dbo.SANPHAM.tensanpham FROM dbo.SANPHAM
WHERE dbo.SANPHAM.gia BETWEEN @gia1 AND @gia2
END
CREATE PROCEDURE timkiemtheoloaihang(@chuoi nvarchar(50))
AS 
BEGIN 
SELECT dbo.SANPHAM.id_sanpham,dbo.SANPHAM.tensanpham
FROM dbo.SANPHAM JOIN dbo.LOAIHANG ON dbo.SANPHAM.id_loaihang=dbo.LOAIHANG.id_loaihang
WHERE (dbo.LOAIHANG.tenloaihang LIKE '%'+ @chuoi +'%') 
END
CREATE PROC DangKiBanSanPham (@id_nguoiban varchar(20),@id_loaihang varchar(20),@tensanpham nvarchar(100),@hang nvarchar(30),@thongtinchitiet nvarchar(500),@gia int)
AS 
BEGIN 
IF(NOT EXISTS(SELECT *FROM dbo.LOAIHANG WHERE id_loaihang=@id_loaihang))
begin
RAISERROR ('Hang khong co trong loai hang',1,1)
RETURN 
end
IF(NOT EXISTS(SELECT *FROM dbo.NGUOIBAN WHERE id_nguoiban=@id_nguoiban ))
BEGIN
RAISERROR ('chua co nguoi ban',1,1)
RETURN
END
DECLARE @id_sanpham VARCHAR(20)
set @id_sanpham = 'SP' + CONVERT(char, 1 + (select count(*) from dbo.SANPHAM))
INSERT INTO dbo.SANPHAM
(
    id_sanpham,
    id_loaihang,
    tensanpham,
    hang,
    thongtinchitiet,
    danhgiatrungbinh,
    gia,
    giagoc
)
VALUES
(   @id_sanpham,  -- id_sanpham - varchar(20)
    @id_loaihang,  -- id_loaihang - varchar(20)
    @tensanpham, -- tensanpham - nvarchar(100)
    @hang, -- hang - nvarchar(30)
    @thongtinchitiet, -- thongtinchitiet - nvarchar(500)
    0.0, -- danhgiatrungbinh - real
    @gia,   -- gia - int
    @gia    -- giagoc - int
)
INSERT INTO dbo.nguoiban_sanpham
(
    id_sanpham,
    id_nguoiban
)
VALUES
(   @id_sanpham, -- id_sanpham - varchar(20)
    @id_nguoiban  -- id_nguoiban - varchar(20)
)
end
