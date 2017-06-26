function showDate() {
    str = " ";
    var d = new Date();     //leading zeros in date
    addLeadZeroAndPrint(d.getDate());
    str += "/";
    addLeadZeroAndPrint((d.getMonth() + 1));
    str += "/";
    str += d.getFullYear() + " ";
    addLeadZeroAndPrint(d.getHours());
    str += ":";
    addLeadZeroAndPrint(d.getMinutes());
    document.getElementById('dateContainer').innerHTML = str;
}

function addLeadZeroAndPrint(num) {
    if (num < 10)
        str += "0";
    str += num;
}

