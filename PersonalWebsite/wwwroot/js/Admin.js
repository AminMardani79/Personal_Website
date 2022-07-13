// banner
const bannerImage = document.querySelector('.bannerImage');
const bannerInput = document.querySelector('.bannerInput');
if (bannerInput) {

    bannerInput.addEventListener('change', (e) => {
        const file = e.target.files[0];
        bannerImage.src = URL.createObjectURL(file);
    })
}

// DoWork
function RemoveDoWork(id) {
    Swal.fire({
        title: 'آیا از حذف کار اطمینان دارید ؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/DeleteDoWork/" + id)
                .done(function () {
                    Swal.fire(
                        'حذف شد',
                        'حذف با موفقیت انجام شد',
                        'success'
                    ).then(() => {
                        location.reload();
                    });
                })
                .fail(() => {
                    Swal.fire(
                        'حذف با مشکل مواجه شد',
                        'error'
                    )
                });
        }
    })
}
// Experience
function RemoveExperience(id) {
    Swal.fire({
        title: 'آیا از حذف تجربه اطمینان دارید ؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/DeleteExperience/" + id)
                .done(function () {
                    Swal.fire(
                        'حذف شد',
                        'حذف با موفقیت انجام شد',
                        'success'
                    ).then(() => {
                        location.reload();
                    });
                })
                .fail(() => {
                    Swal.fire(
                        'حذف با مشکل مواجه شد',
                        'error'
                    )
                });
        }
    })
}
// Major
function RemoveMajor(id) {
    Swal.fire({
        title: 'آیا از حذف تجربه اطمینان دارید ؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/DeleteMajor/" + id)
                .done(function () {
                    Swal.fire(
                        'حذف شد',
                        'حذف با موفقیت انجام شد',
                        'success'
                    ).then(() => {
                        location.reload();
                    });
                })
                .fail(() => {
                    Swal.fire(
                        'حذف با مشکل مواجه شد',
                        'error'
                    )
                });
        }
    })
}
// Messages
const checkboxes = $(".show_message");
checkboxes.change((e) => {
    $.ajax({
        type: "Get",
        url: "/ShowMessage",
        data: { id: e.target.id },
        success: () => {
            console.log("success");
        },
        error: (e) => {
            console.log(e);
        }
    });
});
function RemoveMessage(id) {
    Swal.fire({
        title: 'آیا از حذف پیام اطمینان دارید ؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/DeleteMessage/" + id)
                .done(function () {
                    Swal.fire(
                        'حذف شد',
                        'حذف با موفقیت انجام شد',
                        'success'
                    );
                    $("#item_" + id).fadeOut(1000);
                })
                .fail(() => {
                    Swal.fire(
                        'حذف با مشکل مواجه شد',
                        'error'
                    )
                });
        }
    })
}
function ShowMessage(id) {
    $('#desc_' + id).fadeToggle();
}
// profile
const image = document.querySelector('.image');
const profileInput = document.querySelector('.profileInput');
if (profileInput) {
    profileInput.addEventListener('change', (e) => {
        const file = e.target.files[0];
        image.src = URL.createObjectURL(file);
    })
}
// project
function RemoveProject(id) {
    Swal.fire({
        title: 'آیا از حذف پروژه اطمینان دارید ؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/DeleteProject/" + id)
                .done(function () {
                    Swal.fire(
                        'حذف شد',
                        'حذف با موفقیت انجام شد',
                        'success'
                    );
                    $("#item_" + id).fadeOut(1000);
                })
                .fail(() => {
                    Swal.fire(
                        'حذف با مشکل مواجه شد',
                        'error'
                    )
                });
        }
    })
}
// category
function AddToCategoryTrash(id) {
    Swal.fire({
        title: 'آیا از حذف دسته بندی اطمینان دارید ؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/AddCategoryToTrashList/" + id)
                .done(function () {
                    Swal.fire(
                        'حذف شد',
                        'حذف با موفقیت انجام شد',
                        'success'
                    );
                    $("#item_" + id).fadeOut(1000);
                })
                .fail(() => {
                    Swal.fire(
                        'حذف با مشکل مواجه شد',
                        'error'
                    )
                });
        }
    })
}
function RemoveCategory(id) {
    Swal.fire({
        title: 'آیا از حذف دسته بندی اطمینان دارید ؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.isConfirmed) {
            $.get("/Admin/DeleteCategory/" + id)
                .done(function () {
                    Swal.fire(
                        'حذف شد',
                        'حذف با موفقیت انجام شد',
                        'success'
                    );
                    $("#item_" + id).fadeOut(1000);
                })
                .fail(() => {
                    Swal.fire(
                        'حذف با مشکل مواجه شد',
                        'error'
                    )
                });
        }
    })
}
function BackToCategory(id) {
    $.get("/Admin/BackToCategoryList/" + id)
        .done(function () {
            Swal.fire(
                'بازیابی',
                'بازیابی با موفقیت انجام شد',
                'success'
            );
            $("#item_" + id).fadeOut(1000);
        })
        .fail(() => {
            Swal.fire(
                'بازیابی با مشکل مواجه شد',
                'error'
            )
        });
}