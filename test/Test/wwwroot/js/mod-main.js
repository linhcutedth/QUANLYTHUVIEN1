(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to

        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();

function sidebarActive() {
    var element = document.getElementById(isClicked);
    var danhmuc = document.getElementById("DanhMuc");
    var CPU = document.getElementById("CPU");
    var RAM = document.getElementById("RAM");
    var congketnoi = document.getElementById("CongKetNoi");
    var manhinh = document.getElementById("ManHinh");
    var chitietsanpham = document.getElementById("ChiTietSanPham");

    danhmuc.classList.add("nav-item");
    CPU.classList.add("nav-item");
    RAM.classList.add("nav-item");
    congketnoi.classList.add("nav-item");
    manhinh.classList.add("nav-item");
    chitietsanpham.classList.add("nav-item");

    element.classList.add("nav-item", "active");
}

const onClick = function () {

    alert(this.id, this.innerHTML);
}
document.getElementById('DanhMuc').onclick = onClick;
document.getElementById('CPU').onclick = onClick;
document.getElementById('RAM').onclick = onClick;

