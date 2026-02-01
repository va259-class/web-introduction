function getTimeAndUpdate(){
    // değişken tanımları : var, let, const
    // var : global değişken
    // let : sadece tanımlı olduğu scope'ta
    //const: sabit ve değiştirilemeyecek değerler için (record)
    const date = new Date();
    let year = date.getFullYear();
    let month = (date.getMonth() + 1).toString().padStart(2, "0");
    let day = date.getDate().toString().padStart(2, "0");

    let hour = date.getHours().toString().padStart(2, "0");
    let minute = date.getMinutes().toString().padStart(2, "0");
    let second = date.getSeconds().toString().padStart(2, "0");

    let currentTimeSpan = document.getElementById("currentTime");
    currentTimeSpan.innerText = `${day}/${month}/${year} ${hour}:${minute}:${second}`;
}

function tickTime() {
    setInterval(() => {
        getTimeAndUpdate();
    }, 1000);
}

function emphasize() {
    let currentTimeSpan = document.getElementById("currentTime");
    currentTimeSpan.style.fontWeight = "bold"
    currentTimeSpan.style.fontSize = 18;
}

console.log("bizim kodlar eklendi");