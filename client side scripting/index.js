

async function fetchData(text) {
  try {
    const url = `https://api.pexels.com/v1/curated?page=${text}&per_page=80`;
    const res = await fetch(url, {
      method: "GET",
      headers: {
        Authorization:
          "A18L6UPAOtZeFZ4vLDzj2fO4wTeto2iIb2aqtyo2EA3agRXRdEN6YFRV",
      },
    });
    const data = await res.json();

    const photos = data.photos; // pics is array of photos coming from pexels

    handleData(photos);

    console.log(data); // debug
  } catch (error) {
    console.log(error);
  }
}

function handleData(photos) {
  const parentDiv = document.getElementById("target");
  parentDiv.innerHTML = "";

  photos.forEach((photo) => {
    const createDiv = document.createElement("div");
    createDiv.classList.add("card");

    const createHeading = document.createElement("h3");
    createHeading.innerText = photo.photographer;

    const createImageTag = document.createElement("img");

    createImageTag.src = photo.src.medium;
    createImageTag.alt = photo.photographer;

    parentDiv.appendChild(createDiv);

    createDiv.appendChild(createHeading);
    createDiv.appendChild(createImageTag);
  });
}

let query = document.getElementById("inp").value;
console.log(query)

document.getElementById("btn-next").addEventListener("click", () => {
  query++;
  if (query !== "") {
    fetchData(query);
  }
});

document.getElementById("btn-pre").addEventListener("click", () => {
  query--;
  console.log(query);
  if (query !== "") {
    fetchData(query);
  }
});
