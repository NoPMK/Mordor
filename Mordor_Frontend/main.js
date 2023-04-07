let orkname;
let type;
let kills;
let weapons;

document.addEventListener('DOMContentLoaded', e => {

    document.getElementById('register').addEventListener('click', () => {
        orkname = document.getElementById('name').value;
        type = document.getElementById('type').value;
        kills = document.getElementById('kills').value;
        weapons = document.getElementById('weapons').value.split(', ');

        let ork = {
            Name: orkname,
            Type: type,
            NumberOfKills: kills,
            Weapons: weapons
        }

        fetch("https://localhost:7072/api/Orks", {
            method: 'POST',
            headers: {
                "Content-type": "application/json",
            },
            body: JSON.stringify(ork),
        })
    })
})