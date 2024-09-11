window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
}

window.printDiv = async (id) => {
    printJS({
        printable: id,
        type: 'html',

        css: ['/css/bootstrap.min.css',
            '/css/admin.css'
        ],
        targetStyles: ['*']
    });
}

window.scroll = async (type) => {
    var y = $(window).scrollTop();

    if (type == 'up')
        $(window).scrollTop(y - 150);
    else
        $(window).scrollTop(y + 150);
}

window.DoSomethingConfirm = async (message) => {
    return await ui.confirm(message);
};

window.DoSomethingAleft = async (message) => {
    await ui.aleft(message);
};

window.DoSomethingLoading = async (isShow) => {
    await ui.loading(isShow);
};

window.DoSomethingNotification = async (message) => {
    await ui.notification(message);
};

const ui = {
    confirm: async (message) => createConfirm(message),
    aleft: async (message) => createAleft(message),
    loading: async (isShow) => createLoading(isShow),
    notification: async (message) => createNotification(message),
}

const createConfirm = (message) => {
    return new Promise((complete, failed) => {
        $('#pMesssage').text(message)
        $('#confirmYes').show();

        $('#confirmYes').off('click');
        $('#confirmNo').off('click');

        $('#confirmYes').on('click', () => { $('.divMessageBox').hide(); complete(true); });
        $('#confirmNo').on('click', () => { $('.divMessageBox').hide(); complete(false); });

        $('.divMessageBox').show();
    });
}

const createAleft = (message) => {
    $('#pMesssage').text(message)
    $('#confirmYes').hide();

    $('#confirmNo').off('click');
    $('#confirmNo').on('click', () => { $('.divMessageBox').hide(); });

    $('.divMessageBox').show();
}

const createLoading = (isShow) => {
    if (isShow == true) {
        $('#admin-container').waitMe({
            effect: 'bounce',
            text: 'Vui lòng chờ...',
            bg: 'rgba(255, 255, 255, 0.2)',
            color: '#393836',
            maxSize: '',
            textPos: 'vertical',
            waitTime: -1,
            fontSize: '18px',
            source: ''
        });
    } else {
        $('#admin-container').waitMe('hide');
    }
}

const createNotification = (message) => {
    toastr.success(message, "Notification", { timeOut: 2000 });
}
