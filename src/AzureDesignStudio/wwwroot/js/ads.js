async function diagram2PicAsync(type, width, height) {
    var diagram = document.getElementById("ads-diagram-canvas");
    var dataUrl = "";
    if (type === "png") {
        dataUrl = await domtoimage.toPng(diagram, {
            bgcolor: '#ffffff',
            width: width,
            height: height,
        });
    } else if (type === "jpeg") {
        dataUrl = domtoimage.toJpeg(diagram, {
            bgcolor: '#ffffff',
            width: width,
            height: height,
        });
    }

    return dataUrl;
}

async function downloadFileFromStream(fileName, contentType, contentStreamReference) {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer], { type: contentType });

    const url = URL.createObjectURL(blob);

    triggerFileDownload(fileName, url);

    URL.revokeObjectURL(url);
}

function triggerFileDownload(fileName, url) {
    const anchorElement = document.createElement('a');
    anchorElement.href = url;

    if (fileName) {
        anchorElement.download = fileName;
    }

    anchorElement.click();
    anchorElement.remove();
}

function getWindowSize() {
    return {
        width: window.innerWidth,
        height: window.innerHeight,
    }
}