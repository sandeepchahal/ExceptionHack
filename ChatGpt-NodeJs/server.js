import express from 'express'
import openAI from 'openai'
import cors from 'cors'
import bodyParser from 'body-parser';

const openai = new openAI({
    apiKey: ""
});

const app = express();
const port = 4000;

app.use(cors());
app.use(bodyParser.json());

app.get("/", (req,res)=>{
    res.send("Server is up & running");
});

app.post('/api/chat', async (req, res) => {

    const question = req.body.question["message"];
    const response = await getAnswer(question);
    res.send(response);

});

app.listen(port, ()=>{
    console.log("Server is started");
});

async function getAnswer(question) {
    var chat = await openai.chat.completions.create({
        messages: [
            {
                role: "system", content: "Please follow these rules for answering the question:" +
                    +" 1. you must answer in one line"
                    + "2. you must answer only if it's relevant to education sector or topic"
                    + "3. answer the question inside the <question> "
            },
            { role: "user", content: `<${question}>` }
        ],
        model: "gpt-3.5-turbo"
    });

    return chat.choices[0].message.content;
}