const dbName = "MyBlazorAppDB";
const storeName = "persons";

function openDB() {
    return new Promise((resolve, reject) => {
        const request = indexedDB.open(dbName, 1);
        request.onupgradeneeded = event => {
            const db = event.target.result;
            db.createObjectStore(storeName, { keyPath: "PersonId" });
        };
        request.onsuccess = event => {
            resolve(event.target.result);
        };
        request.onerror = event => {
            reject(event.target.error);
        };
    });
}

async function savePersons(persons) {
    try {
        const db = await openDB();
        const transaction = db.transaction(storeName, "readwrite");
        const store = transaction.objectStore(storeName);

        persons.forEach(person => store.put(person));

        // Wait for the transaction to complete before returning
        await transaction.complete;

        return true; // Transaction completed successfully
    } catch (error) {
        console.error("Error saving persons::::::::::::::::::::::::", error);
        return false; // Transaction failed
    }
}

async function getPersons() {
    const db = await openDB();
    const transaction = db.transaction(storeName, "readonly");
    const store = transaction.objectStore(storeName);
    return store.getAll();
}
