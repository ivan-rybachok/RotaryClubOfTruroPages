// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function startAutoLogout() {
    // setup timeout that will occur when session has expired (20 minutes = 60000 * 20 milliseconds)
    window.setTimeout(() => document.location = "/", 60000 * 60);
    // setup timeout that will occur when session about to expire to warn user
    window.setTimeout(() => document.getElementById("lblExpire").innerHTML = "WARNING : Session is about to expire! You have 2 minutes remaining", 60000 * 18);
}

function showname () {
    var name1 = document.getElementById('btnUpload1').value;
    var name2 = document.getElementById('btnUpload2').value;
    // var name3 = document.getElementById('btnUpload3').value;
    // regex to remove everything before (and including) the last \.
    name1 = name1.replace(/^.*[\\\/]/, '');
    name2 = name2.replace(/^.*[\\\/]/, '');
    // name3 = name3.replace(/^.*[\\\/]/, '');
    document.getElementById('upload1').innerHTML = name1;
    document.getElementById('upload2').innerHTML = name2;
    // document.getElementById('upload3').innerHTML = name3;

}