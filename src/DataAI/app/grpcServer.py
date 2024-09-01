# grpc_server.py
from concurrent import futures
import grpc
from app import aiPrompt_pb2,aiPrompt_pb2_grpc
import app.ai_service as aiService;
class AiPromptService(aiPrompt_pb2_grpc.AiPromptService):
    def Ask(self, request, context):       
        ai_service = aiService.GroqService("https://api.groq.com/openai/v1/chat/completions","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")        
        ans=ai_service.get_answer(request.prompt,request.system_message,request.response_format,request.model)
        print("here")
        return aiPrompt_pb2.AiPromptResponse(answer=f'{ans}')

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    aiPrompt_pb2_grpc.add_AiPromptServiceServicer_to_server(AiPromptService(), server)
    server.add_insecure_port('127.0.0.1:5100')
    server.start()
    server.wait_for_termination()

if __name__ == '__main__':
    serve()
