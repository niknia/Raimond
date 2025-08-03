import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput } from '@mantine/core';
import { useCurQuizsubmissions } from '@/data/curquizsubmissions/curquizsubmissions.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurQuizsubmissionsDto } from '@/data/curquizsubmissions/curquizsubmissions.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurQuizsubmissions();
    const { data: curQuizsubmissionsData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingQuizSubmission, setEditingQuizSubmission] = useState<CurQuizsubmissionsDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curQuizsubmissionsData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurQuizsubmissionsDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'name',
            header: 'نام ارسال آزمون',
            size: 200,
        },
        {
            accessorKey: 'createTime',
            header: 'تاریخ ایجاد',
            size: 150,
            cell: ({ getValue }: { getValue: () => any }) => {
                const date = getValue() as string;
                return date ? new Date(date).toLocaleDateString('fa-IR') : '-';
            },
        },
    ], []);

    // هندل‌های CRUD
    const handleEdit = (row: CurQuizsubmissionsDto) => {
        setEditingQuizSubmission(row);
        open();
    };

    const handleDelete = async (row: CurQuizsubmissionsDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'ارسال آزمون با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف ارسال آزمون',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingQuizSubmission(null);
        open();
    };

    const handleSave = async (values: Partial<CurQuizsubmissionsDto>) => {
        try {
            if (editingQuizSubmission) {
                await updateMutation.mutateAsync({ id: editingQuizSubmission.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'ارسال آزمون با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'ارسال آزمون جدید با موفقیت ایجاد شد',
                    color: 'green',
                });
            }
            close();
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در ذخیره‌سازی',
                color: 'red',
            });
        }
    };

    return (
        <BasePage>
            <Stack gap="lg">
                <Box>
                    <Title order={2}>مدیریت ارسال‌های آزمون</Title>
                    <Text c="dimmed">مدیریت ارسال‌های مختلف آزمون</Text>
                </Box>

                <DkdGrid
                    columns={columns}
                    data={data}
                    isLoading={isLoading}
                    rtl
                    height={600}
                    selectedRowId={selectedRowId}
                    onRowClick={(row: any) => setSelectedRowId(row.original.id.toString())}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                    onAdd={handleAdd}
                    initialPageSize={15}
                />

                {/* Modal برای افزودن/ویرایش */}
                <Modal 
                    opened={opened} 
                    onClose={close} 
                    title={editingQuizSubmission ? 'ویرایش ارسال آزمون' : 'افزودن ارسال آزمون جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام ارسال آزمون"
                            placeholder="نام ارسال آزمون"
                            defaultValue={editingQuizSubmission?.name || ''}
                            name="name"
                            required
                        />
                        
                        <Group justify="flex-end" mt="md">
                            <Button variant="outline" onClick={close}>
                                انصراف
                            </Button>
                            <Button 
                                onClick={() => {
                                    const formData = new FormData(document.querySelector('form') as HTMLFormElement);
                                    const values = {
                                        name: (formData.get('name') as string) || '',
                                    };
                                    handleSave(values);
                                }}
                                loading={createMutation.isPending || updateMutation.isPending}
                            >
                                {editingQuizSubmission ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
} 