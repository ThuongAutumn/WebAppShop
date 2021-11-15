//function my() {
//    var hidden = document.getElementById('kbu1');
//    if (hidden.style.display === 'none') hidden.style.display = 'block';
//    else hidden.style.display = 'none';
//}

HTMLCollection.prototype.click = function (f) {
    for (var i = this.length - 1; i >= 0; i--) {
        this[i].onclick = f;
    }
};
NodeList.prototype.change = function (f) {
    for (var i = this.length - 1; i >= 0; i--) {
        this[i].onchange = f;
    }
};
HTMLElement.prototype.change = function (f) {
    this.onchange = f;
};
NodeList.prototype.check = function (v) {
    for (var i = 0; i < this.length; i++) {
        this[i].checked = v;
    }
};
function confirmDelete() {
    return confirm('Are you sure delete');
};

function toData(o) {
    var a = new Array();
    for (var k in o) {
        a.push(k + '=' + o[k]);
    }
    return a.join('&');
}
var ajax = {};
ajax.post = function (o, url, f) {
    var xhr = new XMLHttpRequest();
    xhr.open('POST', url);
    xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
    var data = toData(o);
    xhr.send(data);
    xhr.onload = function () {
        f.call(this, xhr.response);
    }
};
