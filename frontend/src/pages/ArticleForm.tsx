import { 
    Dialog, DialogTitle, DialogContent, DialogContentText, TextField, DialogActions, Button,
    FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, OutlinedInput, Box, Chip
} from "@mui/material";
import { useState } from "react";
import { Category, Tag } from "../models";
import { Article } from "../models/Article"
import { postNews } from "../services/newsService";

interface IProps {
    open: boolean,
    categories: Category[],
    tags: Tag[],
    authorId: number | null,
    handlePopupClose: () => void
};

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

export const ArticleForm = (props: IProps) => {

    const [selectedCategory, setSelectedCategory] = useState<Category | null>(null);
    const [selectedTags, setSelectedTags] = useState<Tag[]>([]);
    const [title, setTitle] = useState<string>('');
    const [text, setText] = useState<string>('');

    const handlePublish = async () => {

        if (!selectedCategory || !title || !text || !selectedTags || !(selectedTags.length > 0)) {
            console.log(selectedCategory)
            console.log(title)
            console.log(text)
            console.log(selectedTags)
            return;
        }

        const article = new Article(
            title,
            text,
            props.authorId as number,
            selectedCategory.id,
            selectedTags.map(t => t.id)
        );

        await postNews(article);
        props.handlePopupClose();
    };

    return (
        <Dialog open={props.open} onClose={props.handlePopupClose}>
            <DialogTitle>Add article</DialogTitle>
            <DialogContent>
            <DialogContentText>
                Fill in the next fields in order to save a new article.
            </DialogContentText>
            <TextField
                autoFocus
                margin="dense"
                id="title"
                label="Title"
                fullWidth
                variant="standard"
                onChange={(e) => setTitle(e.target.value)}
                required
            />
            <TextField
                id="text"
                margin="dense"
                label="Text"
                multiline
                rows={4}
                fullWidth
                onChange={(e) => setText(e.target.value)}
                required
            />
            <FormControl required fullWidth>
                <InputLabel id="demo-simple-select-label">Category</InputLabel>
                <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    value={selectedCategory?.id.toString() || ""}
                    label="Categories"
                    onChange={(event: SelectChangeEvent) => {
                        const category = props.categories.find(c => c.id == (event.target.value as unknown as number));
                        setSelectedCategory(category ? category : null);
                    }}
                >
                    {
                        props.categories && props.categories.map((category) => (
                            <MenuItem key={category.id} value={category.id.toString()}>{category.name}</MenuItem>
                        ))
                    }
                </Select>
            </FormControl>
            <FormControl required fullWidth>
                <InputLabel id="multiple-chip-tags">Tags</InputLabel>
                <Select
                    labelId="multiple-chip-tags"
                    id="multiple-tags"
                    multiple
                    value={selectedTags.map(t => t.id)}
                    onChange={(event: SelectChangeEvent<number[]>) => {
                        const { target: { value } } = event;
                        const selected = props.tags.filter(t => (value as number[]).includes(t.id));
                        setSelectedTags(selected);
                    }}
                    input={<OutlinedInput id="select-multiple-tags" label="Chip" />}
                    renderValue={(selected) => (
                        <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 0.5 }}>
                        {
                            props.tags.filter(t => selected.includes(t.id))
                            .map((value) => (
                                <Chip key={value.id} label={value.name} />
                            ))
                        }
                        </Box>
                    )}
                    MenuProps={MenuProps}
                >
                {
                    props.tags && props.tags.map((tag) => (
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
            </DialogContent>
            <DialogActions>
            <Button onClick={handlePublish}>Publish</Button>
            </DialogActions>
        </Dialog>
    )
};