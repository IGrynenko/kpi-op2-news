import { News } from "../models/News";

const NewsBlock = (item: News) => {

    return (
        <div className="NewsBlock">
            <p className="ArticleTitle">{ item.title }</p>
            <p>{ item.text }</p>
            <p className="Author">by { item.author.firstName } { item.author.lastName }</p>
            {
                item.tags && item.tags.length > 0 &&
                <div className="ArticleTags">
                    {
                        item.tags.map((tag) => (
                            <div className="ArticleTag" key={tag.id}>#{ tag.name }</div>
                        ))
                    }
                </div>
            }
        </div>
    );
};

export default NewsBlock;