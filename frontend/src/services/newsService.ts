import { Article, Author, Category, News } from "../models";
import { BaseModel } from "../models/BaseModel";
import { getToken } from "./loginService";

async function getAllNews(): Promise<News[]> {

    const response = await fetch('https://localhost:7046/api/news');

    if (!response.ok) {
        console.log('Status: ' + response.status);
        return [];
    }

    const data = await response.json();
    return data as News[];
}

async function getByAuthor(author: Author): Promise<News[]> {
    return await getById<Author>(author, 'author');
};

async function getByCategory(category: Category): Promise<News[]> {
    return await getById<Category>(category, 'category');
};

async function getById<T extends BaseModel>(obj: T, path: string): Promise<News[]> {
   
    const response = await fetch(`https://localhost:7046/api/news/${path}/${obj.id.toString()}`);

    if (!response.ok) {
        console.log('Status: ' + response.status);
        return [];
    }

    const data = await response.json();
    return data as News[];
}

async function getByTags<T extends BaseModel>(objs: T[]): Promise<News[]> {

    const response = await fetch('https://localhost:7046/api/news/tags', {
        method: 'POST',
        body: JSON.stringify(objs.map(o => o.id)),
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        }
    });

    if (!response.ok) {
        console.log('Status: ' + response.status);
        return [];
    }

    const data = await response.json();
    return data as News[];
}

async function postNews(article: Article): Promise<void> {

    const response = await fetch('https://localhost:7046/api/news', {
        method: 'POST',
        body: JSON.stringify(article),
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8',
            'Authorization': `Bearer ${getToken()}`
        }
    });

    if (!response.ok) {
        console.log('Status: ' + response.status);
    }
}

export { getByAuthor, getByCategory, getByTags, getAllNews, postNews };