function ShowMessage(title, text, theme) {
    window.createNotification({
        closeOnClick: true,
        displayCloseButton: false,
        positionClass: 'nfc-center',
        showDuration: 8000,
        theme: theme !== '' ? theme : 'success'
    })({
        //title: title !== '' ? title : 'اعلان',
        message: decodeURI(text)
    });
}