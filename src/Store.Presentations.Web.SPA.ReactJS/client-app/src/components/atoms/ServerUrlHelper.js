const ServerAbsoluteUrl = "https://localhost:4101";

const ServerUrl = (relativeUrl) => {
    return `${ServerAbsoluteUrl}/${relativeUrl}`;
}

export { ServerAbsoluteUrl, ServerUrl };