import { Box, FormControl, InputLabel, Select, MenuItem, SelectChangeEvent, OutlinedInput, Chip, Button, Fab } from "@mui/material";
import { useEffect, useState } from "react";
import { Display } from "../helpers/display";
import { Category, News, Author, Tag } from "../models";
import { isAuthenticated } from "../services/loginService";
import { getAllNews, getByAuthor, getByCategory, getByTags } from "../services/newsService";
import { ArticleForm } from "./ArticleForm";
import { LoginPopup } from "./LoginPopup";
import NewsBlock from "./NewsBlock";

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
    PaperProps: {
        style: {
        maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
        width: 250,
        }   
    }
};

const NewsFeed = () => {
    const [news, setNews] = useState<News[]>([]);
    const [categories, setCategories] = useState<Category[]>([]);
    const [authors, setAuthors] = useState<Author[]>([]);
    const [tags, setTags] = useState<Tag[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [filter, setFilter] = useState<Display>(Display.All);
    const [selectedCategory, setSelectedCategory] = useState<Category | undefined | null>(null);
    const [selectedAuthor, setSelectedAuthor] = useState<Author | undefined | null>(null);
    const [selectedTags, setSelectedTags] = useState<Tag[]>([]);
    const [showLogin, setShowLogin] = useState<boolean>(false);
    const [showAddArticle, setShowAddArticle] = useState<boolean>(false);
    const [currentAuthorId, setCurrentAuthorId] = useState<number | null>(null);

    useEffect(() => {
        const getData = async () => {
            const responses = await Promise.all([
                fetch('https://localhost:7046/api/news'), //TODO: take out consts
                fetch('https://localhost:7046/api/categories'),
                fetch('https://localhost:7046/api/authors'),
                fetch('https://localhost:7046/api/tags'),
            ]);

            const errors = responses.filter(r => !r.ok);

            if (errors && errors.length > 0) {
                throw Error(`Fetching error: ${errors.map(e => e.statusText)}`);
            }

            const json = responses.map(r => r.json());
            const data = await Promise.all(json);

            return data;
        };

        getData()
        .then(data => {
            setNews(data[0]);
            setCategories(data[1]);
            setAuthors(data[2]);
            setTags(data[3]);
            setLoading(false);
        })
        .catch(console.error);
        
    }, []);

    const handleSearchClick = async () => {
        switch (filter) {
            case Display.All:
                const news = await getAllNews();
                setNews(news);
                break;
            case Display.ByAuthor:
                console.log('BY AUTHOR');
                if (selectedAuthor) {
                    const news = await getByAuthor(selectedAuthor);
                    setNews(news);
                } 
                break;
            case Display.ByCategory:
                console.log('BY CATEGORY');
                if (selectedCategory) {
                    const news = await getByCategory(selectedCategory);
                    setNews(news);
                }
                break;
            case Display.ByTags:
                console.log('BY TAGS');
                if (selectedTags) {
                    const news = await getByTags(selectedTags);
                    console.log(news);
                    setNews(news);
                }
                break;
            default:
                throw Error();
        }
    };

    const handlePopupClose = () => {
        if (showLogin) {
            setShowLogin(false);
        }
        if (showAddArticle) {
            setShowAddArticle(false);
        }
      };

    return (
        <div className="NewsFeed">
            <LoginPopup open={showLogin} handlePopupClose={handlePopupClose}/>
            <div className="Selection">
                <div>
                    <FormControl sx={{ m: 1, width: 300, mt: 3 }} size="small">
                        <InputLabel id="simple-select-filter">Display</InputLabel>
                        <Select
                            displayEmpty
                            labelId="simple-select-filter"
                            id="select-filter"
                            value={filter.toString()}
                            label="Display"
                            onChange={(event: SelectChangeEvent) => setFilter(event.target.value as unknown as number as Display)}
                        >
                            <MenuItem value={Display.All}>All</MenuItem>
                            <MenuItem value={Display.ByAuthor}>By author</MenuItem>
                            <MenuItem value={Display.ByCategory}>By category</MenuItem>
                            <MenuItem value={Display.ByTags}>By tags</MenuItem>
                        </Select>
                    </FormControl>
                </div>
                <div>
                    {
                        filter === Display.ByCategory &&
                        <FormControl sx={{ m: 1, width: 300, mt: 3 }} size="small">
                            <InputLabel id="simple-select-category">Categories</InputLabel>
                            <Select
                                displayEmpty
                                labelId="simple-select-category"
                                id="simple-category"
                                value={selectedCategory?.id.toString() ?? '0'}
                                label="Category"
                                onChange={(event: SelectChangeEvent) => {
                                    const category = categories.find(c => c.id === (event.target.value as unknown as number));
                                    setSelectedCategory(category);
                                }}
                            >
                                <MenuItem value={0}>Select any</MenuItem>
                                {
                                    categories.map((category, index) => (
                                        <MenuItem key={category.id} value={category.id}>{category.name}</MenuItem>
                                    ))
                                }
                            </Select>
                        </FormControl>
                    }
                </div>
                <div>
                    {
                        filter === Display.ByAuthor &&
                        <FormControl sx={{ m: 1, width: 300, mt: 3 }} size="small">
                            <InputLabel id="simple-select-category">Authors</InputLabel>
                            <Select
                                displayEmpty
                                labelId="simple-select-author"
                                id="simple-author"
                                value={selectedAuthor?.id.toString() ?? '0'}
                                label="Author"
                                onChange={(event: SelectChangeEvent) => {
                                    const author = authors.find(c => c.id === (event.target.value as unknown as number));
                                    setSelectedAuthor(author);
                                }}
                            >
                                <MenuItem value={0}>Select any</MenuItem>
                                {
                                    authors.map((author, index) => (
                                        <MenuItem key={author.id} value={author.id}>{author.firstName} {author.lastName}</MenuItem>
                                    ))
                                }
                            </Select>
                        </FormControl>
                    }
                </div>
                <div>
                    {
                        filter === Display.ByTags &&
                        <FormControl sx={{ m: 1, width: 300 }} size="small">
                            <InputLabel id="multiple-chip-tags">Tags</InputLabel>
                            <Select
                                labelId="multiple-chip-tags"
                                id="multiple-tags"
                                multiple
                                value={selectedTags.map(t => t.id)}
                                onChange={(event: SelectChangeEvent<number[]>) => {
                                    const { target: { value } } = event;
                                    const selected = tags.filter(t => (value as number[]).includes(t.id));
                                    setSelectedTags(selected);
                                }}
                                input={<OutlinedInput id="select-multiple-tags" label="Chip" />}
                                renderValue={(selected) => (
                                    <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 0.5 }}>
                                    {
                                        tags.filter(t => selected.includes(t.id))
                                        .map((value) => (
                                            <Chip key={value.id} label={value.name} />
                                        ))
                                    }
                                    </Box>
                                )}
                                MenuProps={MenuProps}
                            >
                            {
                                tags && tags.map((tag) => (
                                    <MenuItem
                                        key={tag.id}
                                        value={tag.id}
                                    >
                                        {tag.name}
                                    </MenuItem>
                                ))
                            }
                            </Select>
                        </FormControl>
                    }
                </div>
                <div className="SelectionBtn">
                    <Button
                        style={{ backgroundColor: "#282c34" }}
                        variant="contained"
                        onClick={handleSearchClick}
                    >
                        Search
                    </Button>
                </div>
            </div>
            {/* <button onClick={() => {
                console.log(showLogin);
                setShowLogin(!showLogin)
            }}>TEST</button> */}
            {
                !loading && news.length > 0 &&
                news.map((item, index) => (
                    <NewsBlock key={item.id} { ... news[index]}/>
                ))
            }
            <div className="AddBtnContainer">
                <Fab 
                    className="AddBtn"
                    aria-label="add"
                    onClick={() => {
                        const {authenticated, authorId} = isAuthenticated();

                        if (!authenticated) {
                            setShowLogin(true);
                            return;
                        }
                        setShowAddArticle(true);
                        setCurrentAuthorId(authorId);
                    }}
                >
                    Add
                </Fab>
                <ArticleForm 
                    handlePopupClose={handlePopupClose}
                    open={showAddArticle}
                    categories={categories}
                    tags={tags}
                    authorId={currentAuthorId}
                />
            </div>
            {
                news.length === 0 &&
                <div className="NoArticles">
                    None articles found
                </div>
            }
        </div>
    )
};

export default NewsFeed;