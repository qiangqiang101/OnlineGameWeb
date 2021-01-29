const swalTheme = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-palovit palovit35',
        cancelButton: 'btn btn-palovit-black palovit35'
    },
    buttonsStyling: false
})

//swalTheme.fire({
//    title: 'Are you sure?',
//    text: "You won't be able to revert this!",
//    icon: 'warning',
//    showCancelButton: true,
//    confirmButtonText: 'Yes',
//    cancelButtonText: 'No',
//    reverseButtons: true
//}).then((result) => {
//    if (result.isConfirmed) {
//        swalTheme.fire(
//          'Deleted!',
//          'Your file has been deleted.',
//          'success'
//        )
//    } else if (
//      result.dismiss === Swal.DismissReason.cancel
//    ) {
//        swalTheme.fire(
//          'Cancelled',
//          'Your imaginary file is safe :)',
//          'error'
//        )
//    }
//})