class User {
    id: number
    name: string;
    token: string;

    constructor(id: number, name: string, token: string) {
        this.id = id;
        this.name = name;
        this.token = token;
    }
}

export { User };