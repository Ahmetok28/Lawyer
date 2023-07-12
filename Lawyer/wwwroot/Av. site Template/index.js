let valueDisplays = document.querySelectorAll(".num");

let interval = 5000;

valueDisplays.forEach((valueDisplays) => {
  let stratValue = 0;
  let endValue = parseInt(valueDisplays.getAttribute("data-val"));
  let duration = Math.floor(interval / endValue);
  let counter = setInterval(function () {
    stratValue += 1;
    valueDisplays.textContent = stratValue;
    if (stratValue == endValue) {
      clearInterval(counter);
    }
  });
});
