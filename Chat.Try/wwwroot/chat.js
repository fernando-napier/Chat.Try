function scrollToEnd(element) {
    console.log("pre scroll height: " + element.scrollHeight);
    console.log("pre scroll top: " + element.scrollTop);
    element.scrollTop = element.scrollHeight - 516;
    console.log("post scroll height: " + element.scrollHeight);
    console.log("post scroll top: " + element.scrollTop);
}