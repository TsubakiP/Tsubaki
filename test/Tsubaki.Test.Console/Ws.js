var ws = new WebSocket('ws://localhost:8888');
ws.onmessage = function (e) {
    if (typeof e.data === 'string') {
        var data = e.data;
        console.log('received: ' + data);
        var logger = document.getElementById('logger');
        logger.innerHTML += '<div>' + data + '</div>';
        logger.scrollTop = logger.scrollHeight;
    }
    //else if (e.data instanceof ArrayBuffer) {
    //}
};

var send = function (id) {
    var element = document.getElementById(id);
    var message = element.value;
    if (message !== '') {
        ws.send(message);
        element.value = '';
    }
}