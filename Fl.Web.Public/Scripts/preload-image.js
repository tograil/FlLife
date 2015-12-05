function init() {
    // quit if this function has already been called
    if (arguments.callee.done) return;

    // flag this function so we don't do the same thing twice
    arguments.callee.done = true;

    // preload images
    preload([
        'images/mob.png',
        'images/mail.png',
        'images/phone.png',
        'images/contactsPopupLeft.png',
        'images/contactsPopupLeftToUp.png',
        'images/contactsPopup.png',
        'images/contactsPopupRight.png'
    ]);

   };

/* for Mozilla */
if (document.addEventListener)
{
    document.addEventListener("DOMContentLoaded", init, false);
}

/* for Internet Explorer */
/*@cc_on @*/
/*@if (@_win32)
    document.write("<script defer src=js/ie_onload.js><"+"/script<");
/*@end @*/

/* for other browsers */
window.onload = init;

function preload(images) {
    if (typeof document.body == "undefined") return;
    try {

        var div = document.createElement("div");
        var s = div.style;
            s.position = "absolute";
        s.top = s.left = 0;
        s.visibility = "hidden";
        document.body.appendChild(div);
        div.innerHTML = "<img src=\"" + images.join("\" /><img src=\"") + "\" />";
        var lastImg = div.lastChild;
        lastImg.onload = function() { document.body.removeChild(document.body.lastChild); };
     }
     catch(e) {
        // Error. Do nothing.
    }
}
