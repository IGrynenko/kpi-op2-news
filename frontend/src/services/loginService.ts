import { User } from "../models/User";

const key = 'newsApplicationUser';

type authenticationResult = {
    authenticated: boolean,
    authorId: number | null
};

function isAuthenticated(): authenticationResult {
    
    const userString = localStorage.getItem(key);

    if (!userString) {
        return { authenticated: false, authorId: null };
    }

    const user = JSON.parse(userString) as User;

    if (user && user.token) {
        return { authenticated: true, authorId: user.id };
    }
    else {
        return { authenticated: false, authorId: null };
    }
}

async function login(login: string, password: string): Promise<boolean> {

    const response = await fetch('https://localhost:7046/api/login', {
        method: 'POST',
        body: JSON.stringify({ login, password }),
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        }
    });

    if (!response.ok) {
        return false;
    }

    const data = await response.json();

    if (!data) {
        throw Error();
    }

    const user = new User(data.id, login, data.token);
    localStorage.setItem(key, JSON.stringify(user));

    return true;
}

function getToken(): string | null {

    const userString = localStorage.getItem(key);

    if (!userString) {
        return null;
    }

    const user = JSON.parse(userString) as User;
    
    return user ? user.token : null;
}

export { login, isAuthenticated, getToken };