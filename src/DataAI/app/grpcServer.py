# grpc_server.py

from concurrent import futures
import grpc
from app import aiPrompt_pb2,aiPrompt_pb2_grpc
class AiPromptService(aiPrompt_pb2_grpc.AiPromptService):
    def Ask(self, request, context):
        return aiPrompt_pb2.AiPromptResponse(answer=f'Hello, {request.prompt}!')

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    aiPrompt_pb2_grpc.add_AiPromptServiceServicer_to_server(AiPromptService(), server)
    server.add_insecure_port('0.0.0.0:8100')
    server.start()
    server.wait_for_termination()

if __name__ == '__main__':
    serve()
